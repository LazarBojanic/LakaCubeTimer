﻿using LakaCubeTimer.model;
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
            string query = "INSERT INTO [time] ([session], [time], [timeInMilliseconds], [isPlusTwo], [isDNF], [scramble], [date]) VALUES (@session, @time, @timeInMilliseconds, @isPlusTwo, @isDNF, @scramble, @date)";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@session", timeResult.session);
            command.Parameters.AddWithValue("@time", timeResult.time);
            command.Parameters.AddWithValue("@timeInMilliseconds", (double)timeResult.timeInMilliseconds);
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
                times.Add(new TimeUserControl(new Time(Int32.Parse(row.ItemArray.GetValue(0).ToString()),
                                                Int32.Parse(row.ItemArray.GetValue(1).ToString()),
                                                row.ItemArray.GetValue(2).ToString(),
                                                Convert.ToInt64(row.ItemArray.GetValue(3)),
                                                Convert.ToBoolean(row.ItemArray.GetValue(4)),
                                                Convert.ToBoolean(row.ItemArray.GetValue(5)),
                                                row.ItemArray.GetValue(6).ToString(),
                                                Convert.ToDateTime(row.ItemArray.GetValue(7)))));
                
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
            Time latestTime = new Time(Int32.Parse(row.ItemArray.GetValue(0).ToString()),
                                                Int32.Parse(row.ItemArray.GetValue(1).ToString()),
                                                row.ItemArray.GetValue(2).ToString(),
                                                Convert.ToInt64(row.ItemArray.GetValue(3)),
                                                Convert.ToBoolean(row.ItemArray.GetValue(4)),
                                                Convert.ToBoolean(row.ItemArray.GetValue(5)),
                                                row.ItemArray.GetValue(6).ToString(),
                                                Convert.ToDateTime(row.ItemArray.GetValue(7)));
            connection.Close();
            return latestTime;
        }
    }
}