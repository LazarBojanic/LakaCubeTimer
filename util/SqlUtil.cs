using LakaCubeTimer.model;
using System.Data.OleDb;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Data;
using static System.Collections.Specialized.BitVector32;
using System.Data.Common;
using LakaCubeTimer.forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Time = LakaCubeTimer.model.Time;

namespace LakaCubeTimer.util {
    public static class SqlUtil {
        public static void saveToDatabase(Time timeResult) {
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "INSERT INTO [time] ([session], [timeInMilliseconds], [initialTimeInMilliseconds], [time], [isPlusTwo], [isDNF], [scramble], [date])" +
                " VALUES (@session, @timeInMilliseconds, @initialTimeInMilliseconds, @time, @isPlusTwo, @isDNF, @scramble, @date)";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", timeResult.session);
            command.Parameters.AddWithValue("@timeInMilliseconds", (double)timeResult.timeInMilliseconds);
            command.Parameters.AddWithValue("@initialTimeInMilliseconds", (double)timeResult.initialTimeInMilliseconds);
            command.Parameters.AddWithValue("@time", timeResult.time);      
            command.Parameters.AddWithValue("@isPlusTwo", timeResult.isPlusTwo);
            command.Parameters.AddWithValue("@isDNF", timeResult.isDNF);
            command.Parameters.AddWithValue("@scramble", timeResult.scramble);
            command.Parameters.Add("@date", OleDbType.DBTimeStamp).Value = Util.dateTimeWithoutMilliseconds(timeResult.date);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static string getBestTime(int session) {
            long bestTime = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT MIN([timeInMilliseconds]) FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            bestTime = (long)command.ExecuteScalar();
            connection.Close();
            return Util.longMillisecondsToString(bestTime);
        }
        public static List<TimeUserControl> fillTimes(int session) {
            List<TimeUserControl> times = new List<TimeUserControl>();
            DataTable timesTable = new DataTable();
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT * FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(timesTable);
            connection.Close();
            foreach(DataRow row in timesTable.Select()) {
                times.Add(new TimeUserControl(new Time(Convert.ToInt32(row.ItemArray.GetValue(0).ToString()),
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
        public static int getMaxId(int session) {
            int maxId = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT MAX([id]) FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            maxId = (int)command.ExecuteScalar();
            connection.Close();
            return maxId;
        }
        public static List<long> timesToCalculate(int numberToGet, int session) {
            List<long> timesToCalculate = new List<long>();
            int id = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT [timeInMilliseconds] FROM [time] WHERE [session] = @session AND [id] = @id";
            for (int i = 0; i < numberToGet; i++) {
                id = getMaxId(session) - i;
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@session", session);
                command.Parameters.AddWithValue("@id", id);
                timesToCalculate.Add((long)command.ExecuteScalar());
            }
            connection.Close();
            return timesToCalculate;
        }
        public static Time getLatestAddedTime(int session) {
            int maxId = getMaxId(session);
            OleDbConnection connection = Util.GetConnection();
            DataTable latestTimeTable = new DataTable();
            connection.Open();
            string query = "SELECT * FROM [time] WHERE [session] = @session AND [id] = @id";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            command.Parameters.AddWithValue("@id", maxId);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(latestTimeTable);
            DataRow row = latestTimeTable.Select()[0];
            Time latestTime = new Time(Convert.ToInt32(row.ItemArray.GetValue(0).ToString()),
                                                Convert.ToInt32(row.ItemArray.GetValue(1).ToString()),
                                                Convert.ToInt64(row.ItemArray.GetValue(2)),
                                                Convert.ToInt64(row.ItemArray.GetValue(3)),
                                                row.ItemArray.GetValue(4).ToString(),
                                                Convert.ToBoolean(row.ItemArray.GetValue(5)),
                                                Convert.ToBoolean(row.ItemArray.GetValue(6)),
                                                row.ItemArray.GetValue(7).ToString(),
                                                Convert.ToDateTime(row.ItemArray.GetValue(8)));
            connection.Close();
            return latestTime;
        }
        public static void updateIsPlusTwo(Time time) {
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "UPDATE [time] SET [isPlusTwo] = @isPlusTwo, [time] = @timePlusTwo, [timeInMilliseconds] = @timeInMillisecondsPlusTwo WHERE [id] = @id";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@isPlusTwo", time.isPlusTwo);
            command.Parameters.AddWithValue("@timePlusTwo", time.time);
            command.Parameters.AddWithValue("@timeInMillisecondsPlusTwo", (double)time.timeInMilliseconds);
            command.Parameters.AddWithValue("@id", time.id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void updateIsDNF(Time time) {
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "UPDATE [time] SET [isDNF] = @isDNF WHERE [id] = @id";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@isDNF", time.isDNF);
            command.Parameters.AddWithValue("@id", time.id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static long getInitialTime(int id) {
            long initialTime = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT [initialTimeInMilliseconds] FROM [time] WHERE [id] = @id";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            initialTime = (long)command.ExecuteScalar();
            connection.Close();
            return initialTime;
        }
        public static void deleteAllFromSession(int session) {
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "DELETE * FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void deleteTime(int session, int id) {
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "DELETE * FROM [time] WHERE [session] = @session AND [id] = @id";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}