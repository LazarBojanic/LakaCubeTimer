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

namespace LakaCubeTimer.util {
    public static class SqlUtil {
        public static void saveToDatabase(Time timeResult) {
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "INSERT INTO [time] ([session], [time], [timeInMilliseconds], [date]) VALUES (@session, @time, @timeInMilliseconds, @date)";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", timeResult.session);
            command.Parameters.AddWithValue("@time", timeResult.time);
            command.Parameters.AddWithValue("@timeInMilliseconds", timeResult.timeInMilliseconds);
            command.Parameters.Add("@date", OleDbType.DBTimeStamp).Value = Util.dateTimeWithoutMilliseconds(timeResult.date);
            command.ExecuteNonQuery();
            connection.Close();
        }
            /*public static double calculateAverageOfFive(int session) {
            double average = 0;
            double bestTime = getBestTime(session);
            double worstTime = getWorstTime(session);
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT AVG([timeInMilliseconds]) FROM (SELECT * FROM [time] WHERE" +
                " [timeInMilliseconds] <> @bestTime AND [timeInMilliseconds] <> @worstTime AND [session] = @session)";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@bestTime", bestTime);
            command.Parameters.AddWithValue("@worstTime", worstTime);
            command.Parameters.AddWithValue("@session", session);
            average = (double)command.ExecuteScalar();
            connection.Close();
            return average;
            }*/
            /*public static double getBestTime(int session) {
            long bestTime = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT MIN([timeInMilliseconds]) FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            bestTime = (long)command.ExecuteScalar();
            connection.Close();
            return Convert.ToDouble(bestTime);
            }*/
            /*public static double getWorstTime(int session) {
            long worstTime = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT MAX([timeInMilliseconds]) FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            worstTime = (long)command.ExecuteScalar();
            connection.Close();
            return Convert.ToDouble(worstTime);
            }*/
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
                times.Add(new TimeUserControl(Int32.Parse(row.ItemArray.GetValue(0).ToString()),
                                                Int32.Parse(row.ItemArray.GetValue(1).ToString()),
                                                row.ItemArray.GetValue(2).ToString(),
                                                Convert.ToDouble(row.ItemArray.GetValue(3)),
                                                Convert.ToDateTime(row.ItemArray.GetValue(4))));
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
            try {
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
            catch (NullReferenceException) {
                MessageBox.Show("Database id's were modified in the meantime", "Error");
                return new List<long>();
            }
        }
    }
}