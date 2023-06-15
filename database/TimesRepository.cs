using LakaCubeTimer.model;
using System.Data;
using LakaCubeTimer.forms;
using LakaCubeTimer.util;
using System.Data.SQLite;

namespace LakaCubeTimer.database
{
    public static class TimesRepository {

        private static SQLiteConnection getConnection() {
            return new SQLiteConnection(Config.getInstance().timesConnectionString);
        }

        public static void saveToDatabase(SolveTime timeResult)
        {
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "INSERT INTO [solveTime] ([solveSession], [solveTimeInMilliseconds], [solveInitialTimeInMilliseconds], [solveTime], [isPlusTwo], [isDNF], [solveScramble], [solveDate])" +
                " VALUES (@solveSession, @solveTimeInMilliseconds, @solveInitialTimeInMilliseconds, @solveTime, @isPlusTwo, @isDNF, @solveScramble, @solveDate)";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", timeResult.solveSession);
            command.Parameters.AddWithValue("@solveTimeInMilliseconds", (double)timeResult.solveTimeInMilliseconds);
            command.Parameters.AddWithValue("@solveInitialTimeInMilliseconds", (double)timeResult.solveInitialTimeInMilliseconds);
            command.Parameters.AddWithValue("@solveTime", timeResult.solveTime);
            command.Parameters.AddWithValue("@isPlusTwo", timeResult.isPlusTwo);
            command.Parameters.AddWithValue("@isDNF", timeResult.isDNF);
            command.Parameters.AddWithValue("@solveScramble", timeResult.solveScramble);
            command.Parameters.AddWithValue("@solveDate", Util.dateTimeWithoutMilliseconds(timeResult.solveDate));
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static string getBestTime(int session)
        {
            SQLiteConnection connection = getConnection();
            DataTable bestTimeTable = new DataTable();
            connection.Open();
            string query = "SELECT MIN([solveTimeInMilliseconds]) AS minSolveTimeInMilliseconds, [isDNF] FROM [solveTime] WHERE [solveSession] = @solveSession GROUP BY [isDNF] HAVING [isDNF] = False";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            var adapter = new SQLiteDataAdapter(command);
            adapter.Fill(bestTimeTable);
            connection.Close();
            if (bestTimeTable.Rows.Count > 0)
            {
                DataRow row = bestTimeTable.Rows[0];
                return Util.longMillisecondsToString(Convert.ToInt64(row["minSolveTimeInMilliseconds"]));
            }
            else
            {
                return "";
            }
        }
        public static List<SolveTimeUserControl> fillTimes(int session)
        {
            List<SolveTimeUserControl> times = new List<SolveTimeUserControl>();
            DataTable timesTable = new DataTable();
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "SELECT * FROM [solveTime] WHERE [solveSession] = @solveSession";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(timesTable);
            connection.Close();
            foreach (DataRow row in timesTable.Select())
            {
                times.Add(new SolveTimeUserControl(new SolveTime(Convert.ToInt32(row.ItemArray.GetValue(0).ToString()),
                                                Convert.ToInt32(row.ItemArray.GetValue(1).ToString()),
                                                Convert.ToInt64(row.ItemArray.GetValue(2)),
                                                Convert.ToInt64(row.ItemArray.GetValue(3)),
                                                row.ItemArray.GetValue(4).ToString(),
                                                Convert.ToBoolean(row.ItemArray.GetValue(5)),
                                                Convert.ToBoolean(row.ItemArray.GetValue(6)),
                                                row.ItemArray.GetValue(7).ToString(),
                                                Convert.ToDateTime(row.ItemArray.GetValue(8)))));

            }
            return times;
        }
        public static long getMaxId(int session)
        {
            long maxId = 0;
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "SELECT MAX([id]) FROM [solveTime] WHERE [solveSession] = @solveSession";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            maxId = (long)command.ExecuteScalar();
            connection.Close();
            return maxId;
        }
        public static List<SolveTimeInMillisecondsWithIsDNF> timesToCalculate(int numberToGet, int session)
        {
            List<SolveTimeInMillisecondsWithIsDNF> timesToCalculateList = new List<SolveTimeInMillisecondsWithIsDNF>();
            SQLiteConnection connection = getConnection();
            DataTable timesToCalculateTable = new DataTable();
            connection.Open();
            string query = "SELECT TOP " + numberToGet + " [solveTimeInMilliseconds], [isDNF] FROM [solveTime] WHERE [solveSession] = @solveSession ORDER BY [id] DESC";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(timesToCalculateTable);
            foreach (DataRow row in timesToCalculateTable.Select())
            {
                if (Convert.ToBoolean(row["isDNF"]))
                {
                    timesToCalculateList.Add(new SolveTimeInMillisecondsWithIsDNF(Convert.ToInt64(row["solveTimeInMilliseconds"]), true));
                }
                else
                {
                    timesToCalculateList.Add(new SolveTimeInMillisecondsWithIsDNF(Convert.ToInt64(row["solveTimeInMilliseconds"]), false));
                }

            }
            connection.Close();
            return timesToCalculateList;
        }
        public static SolveTime getLatestAddedTime(int session)
        {
            long maxId = getMaxId(session);
            SQLiteConnection connection = getConnection();
            DataTable latestTimeTable = new DataTable();
            connection.Open();
            string query = "SELECT * FROM [solveTime] WHERE [solveSession] = @solveSession AND [id] = @id";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            command.Parameters.AddWithValue("@id", maxId);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(latestTimeTable);
            DataRow row = latestTimeTable.Select()[0];
            SolveTime latestTime = new SolveTime(Convert.ToInt32(row["id"].ToString()),
                                                Convert.ToInt32(row["solveSession"].ToString()),
                                                Convert.ToInt64(row["solveTimeInMilliseconds"]),
                                                Convert.ToInt64(row["solveInitialTimeInMilliseconds"]),
                                                row["solveTime"].ToString(),
                                                Convert.ToBoolean(row["isPlusTwo"]),
                                                Convert.ToBoolean(row["isDNF"]),
                                                row["solveScramble"].ToString(),
                                                Convert.ToDateTime(row["solveDate"]));
            connection.Close();
            return latestTime;
        }
        public static void updateIsPlusTwo(SolveTime time)
        {
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "UPDATE [solveTime] SET [isPlusTwo] = @isPlusTwo, [solveTime] = @timePlusTwo, [solveTimeInMilliseconds] = @solveTimeInMillisecondsPlusTwo WHERE [id] = @id";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@isPlusTwo", time.isPlusTwo);
            command.Parameters.AddWithValue("@timePlusTwo", time.solveTime);
            command.Parameters.AddWithValue("@solveTimeInMillisecondsPlusTwo", (double)time.solveTimeInMilliseconds);
            command.Parameters.AddWithValue("@id", time.id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void updateIsDNF(SolveTime time)
        {
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "UPDATE [solveTime] SET [isDNF] = @isDNF WHERE [id] = @id";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@isDNF", time.isDNF);
            command.Parameters.AddWithValue("@id", time.id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static long getInitialTime(int id)
        {
            long initialTime = 0;
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "SELECT [solveInitialTimeInMilliseconds] FROM [solveTime] WHERE [id] = @id";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            initialTime = (long)command.ExecuteScalar();
            connection.Close();
            return initialTime;
        }
        public static void deleteAllFromSession(int session)
        {
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "DELETE FROM [solveTime] WHERE [solveSession] = @solveSession";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void deleteTime(int session, int id)
        {
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "DELETE FROM [solveTime] WHERE [solveSession] = @solveSession AND [id] = @id";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static long getNumberOfSolvesForAverage(int session)
        {
            SQLiteConnection connection = getConnection();
            connection.Open();
            string query = "SELECT COUNT ([id]) FROM [solveTime] WHERE [solveSession] = @solveSession";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@solveSession", session);
            long numberOfSolvesForAverage = (long)command.ExecuteScalar();
            connection.Close();
            return numberOfSolvesForAverage;
        }
    }
}