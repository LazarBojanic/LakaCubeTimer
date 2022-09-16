using LakaCubeTimer.model;
using System.Data.OleDb;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.Data;
using static System.Collections.Specialized.BitVector32;

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
        public static long calculateAverageOfFive(int session) {
            long average = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT AVG(timeInMilliseconds) AS Ao5 FROM @timesForAverageOfFive WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@timesForAverageOfFive", timesForAverageOfFive(session, connection));
            command.Parameters.AddWithValue("@session", session);
            average = (long)command.ExecuteScalar();
            connection.Close();
            return average;
        }
        public static DataTable timesForAverageOfFive(int session, OleDbConnection connection) {
            double bestTime = getBestTime(session);
            double worstTime = getWorstTime(session);
            DataTable timesForAverageOfFive = new DataTable();      
            string query = "SELECT timeInMilliseconds FROM [time] WHERE timeInMilliseconds != @bestTime AND timeInMilliseconds != @worstTime WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@bestTime", bestTime);
            command.Parameters.AddWithValue("@worstTime", worstTime);
            command.Parameters.AddWithValue("@session", session);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            dataAdapter.Fill(timesForAverageOfFive);
            return timesForAverageOfFive;
        }
        public static double getBestTime(int session) {
            long bestTime = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT MIN(timeInMilliseconds) AS BestTime FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            bestTime = (long)command.ExecuteScalar();
            connection.Close();
            return Convert.ToDouble(bestTime);
        }
        public static double getWorstTime(int session) {
            long worstTime = 0;
            OleDbConnection connection = Util.GetConnection();
            connection.Open();
            string query = "SELECT MAX(timeInMilliseconds) AS BestTime FROM [time] WHERE [session] = @session";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", session);
            worstTime = (long)command.ExecuteScalar();
            connection.Close();
            return Convert.ToDouble(worstTime);
        }
    }
}