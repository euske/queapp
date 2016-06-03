using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace QueApp
{
    public class Database
    {
        private SQLiteConnection connection;

        public Database(SQLiteConnection conn)
        {
            this.connection = conn;
            createTables();
        }

        private void createTables() 
        {
            using (SQLiteCommand cmd = new SQLiteCommand(this.connection))
            {
                try
                {
                    cmd.CommandText = "CREATE TABLE Class (classId INTEGER PRIMARY KEY, className TEXT);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE Student (studentId INTEGER PRIMARY KEY, classId INTEGER, studentName TEXT);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "CREATE TABLE Question (questionId INTEGER PRIMARY KEY, studentId INTEGER, questionDate TEXT, questionText TEXT, answerScore INTEGER);";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Database: SQLite tables created.");
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Database: "+e);
                }
            }
        }

        public int[] GetClassIds()
        {
            List<int> ids = new List<int>();

            using (SQLiteCommand cmd = new SQLiteCommand(this.connection))
            {
                try
                {
                    cmd.CommandText = "SELECT classId FROM Class;";
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            ids.Add(id);
                        }
                    }
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Database.GetClassIds: " + e);
                }
            }
            return ids.ToArray();
        }

        public string GetClassName(int classId)
        {
            string name = null;
            using (SQLiteCommand cmd = new SQLiteCommand(this.connection))
            {
                try
                {
                    cmd.CommandText = "SELECT className FROM Class WHERE classId=@classId;";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@classId", classId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(0);
                        }
                    }
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Database.GetClassName: " + e);
                }
            }
            return name;
        }

        public int RegisterNewClass(string className, string[] studentNames)
        {
            int classId = -1;
            using (SQLiteCommand cmd = new SQLiteCommand(this.connection))
            {
                try
                {
                    cmd.CommandText = "INSERT INTO Class VALUES (NULL, @className);";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@className", className);
                    cmd.ExecuteNonQuery();
                    classId = (int) this.connection.LastInsertRowId;

                    foreach (string studentName in studentNames)
                    {
                        cmd.CommandText = "INSERT INTO Student VALUES (NULL, @classId, @studentName);";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@classId", classId);
                        cmd.Parameters.AddWithValue("@studentName", studentName);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Database.RegisterNewClass: " + e);
                }
            }
            return classId;
        }
    }
}
