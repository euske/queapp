﻿//  -*- tab-width: 4 -*-
//  Database.cs
//
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace QueApp {

	/// <summary>
	///   授業IDを伝える EventArgs。
	/// </summary>
	public class ClassIdEventArgs : EventArgs {

		public int classId;
		
		public ClassIdEventArgs(int classId) {
			this.classId = classId;
		}
		
	}
	
	/// <summary>
	///   データベースに対する処理をすべておこなう DAO クラス。
	///   SQL文はすべてこのクラスに集約されている。
	/// </summary>
	public class Database {

		// SQLite への接続。
		private SQLiteConnection connection;

		// 質問記録に変化があったときに fire する。
		public event EventHandler<ClassIdEventArgs> RecordUpdated;

		/// <summary>
		///   コンストラクタ。
		/// </summary>
		public Database(SQLiteConnection conn) {
			this.connection = conn;
			createTables();
		}

		/// <summary>
		///   各種テーブルを初期化する。
		///   初回起動時にのみ実行され、2度目以降のエラーは無視する。
		/// </summary>
		private void createTables() {
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					// Class テーブル。
					cmd.CommandText = (
						"CREATE TABLE Class " +
						"(classId INTEGER PRIMARY KEY, className TEXT);");
					cmd.ExecuteNonQuery();
					// Student テーブル。
					cmd.CommandText = (
						"CREATE TABLE Student " +
						"(studentId INTEGER PRIMARY KEY, classId INTEGER, studentName TEXT);");
					cmd.ExecuteNonQuery();
					// Question テーブル。
					cmd.CommandText = (
						"CREATE TABLE Question " +
						"(questionId INTEGER PRIMARY KEY, studentId INTEGER, " +
						" questionDate TEXT, questionText TEXT, answerScore INTEGER);");
					cmd.ExecuteNonQuery();
					Console.WriteLine("Database: SQLite tables created.");
				} catch (SQLiteException e) {
					Console.WriteLine("Database: " + e);
				}
			}
		}

		/// <summary>
		///   登録されている授業のID一覧を返す。
		/// </summary>
		public int[] GetClassIds() {
			List<int> ids = new List<int>();

			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = "SELECT classId FROM Class;";
					using (SQLiteDataReader reader = cmd.ExecuteReader()) {
						while (reader.Read()) {
							int id = reader.GetInt32(0);
							ids.Add(id);
						}
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.GetClassIds: " + e);
				}
			}
			return ids.ToArray();
		}

		/// <summary>
		///   指定された授業IDの授業名を返す。
		/// </summary>
		public string GetClassName(int classId) {
			string name = null;
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = "SELECT className FROM Class WHERE classId=@classId;";
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@classId", classId);
					using (SQLiteDataReader reader = cmd.ExecuteReader()) {
						while (reader.Read()) {
							name = reader.GetString(0);
						}
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.GetClassName: " + e);
				}
			}
			return name;
		}

		/// <summary>
		///   新規に授業を登録し、その授業IDを返す。
		/// </summary>
		public int RegisterNewClass(string className, string[] studentNames) {
			int classId = -1;
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = "INSERT INTO Class VALUES (NULL, @className);";
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@className", className);
					cmd.ExecuteNonQuery();
					classId = (int)this.connection.LastInsertRowId;

					foreach (string studentName in studentNames) {
						cmd.CommandText = ("INSERT INTO Student VALUES " +
										   "(NULL, @classId, @studentName);");
						cmd.Prepare();
						cmd.Parameters.AddWithValue("@classId", classId);
						cmd.Parameters.AddWithValue("@studentName", studentName);
						cmd.ExecuteNonQuery();
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.RegisterNewClass: " + e);
				}
			}
			return classId;
		}

		/// <summary>
		///   指定された授業IDでこれまでに記録された質問数を返す。
		/// </summary>
		public int GetNumberOfClassRecords(int classId) {
			int nrecords = -1;
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = (
						"SELECT count(questionId) FROM Question, Student " +
						"WHERE Student.studentId = Question.studentId " +
						"AND classId=@classId;");
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@classId", classId);
					using (SQLiteDataReader reader = cmd.ExecuteReader()) {
						while (reader.Read()) {
							nrecords = reader.GetInt32(0);
						}
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.GetNumberOfClassRecords: " + e);
				}
			}
			return nrecords;
		}

		/// <summary>
		///   指定された授業で、次にあてるべき生徒IDを返す。
		/// </summary>
		public int GetNextStudentId(int classId) {
			List<int> students = new List<int>();
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = (
						"SELECT studentId, " +
						"(SELECT count(questionId) FROM Question" +
						" WHERE Student.studentId = Question.studentId) " +
						"FROM Student WHERE classId=@classId;");
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@classId", classId);
					using (SQLiteDataReader reader = cmd.ExecuteReader()) {
						int mincount = int.MaxValue;
						while (reader.Read()) {
							int studentId = reader.GetInt32(0);
							int count = reader.GetInt32(1);
							if (count < mincount) {
								mincount = count;
								students.Clear();
							}
							if (count == mincount) {
								students.Add(studentId);
							}
						}
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.GetNextStudentId: " + e);
				}
			}

			if (students.Count == 0) {
				return -1;
			}
			Random rand = new Random();
			int i = rand.Next(students.Count);
			return students[i];
		}

		/// <summary>
		///   指定された生徒IDに対する生徒名を返す。
		/// </summary>
		public string GetStudentName(int studentId) {
			string name = null;
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = (
						"SELECT studentName FROM Student " +
						"WHERE studentId=@studentId;");
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@studentId", studentId);
					using (SQLiteDataReader reader = cmd.ExecuteReader()) {
						while (reader.Read()) {
							name = reader.GetString(0);
						}
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.GetStudentName: " + e);
				}
			}
			return name;
		}

		/// <summary>
		///   生徒に対する質問とその答えを記録する。
		/// </summary>
		public void StoreResult(int classId, int studentId,
								string questionText, int answerScore) {
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = (
						"INSERT INTO Question "+
						"(studentId, questionDate, questionText, answerScore) " +
						"VALUES (@studentId, datetime('now'), @questionText, @answerScore);");
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@studentId", studentId);
					cmd.Parameters.AddWithValue("@questionText", questionText);
					cmd.Parameters.AddWithValue("@answerScore", answerScore);
					cmd.ExecuteNonQuery();
					if (RecordUpdated != null) {
						RecordUpdated(this, new ClassIdEventArgs(classId));
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.StoreResult: " + e);
				}
			}
		}

		/// <summary>
		///   指定された授業IDの全回答を DataTable 型で返す。
		/// </summary>
		public DataTable GetQuestionResultTable(int classId) {
			DataTable result = new DataTable();
			result.Columns.Add("QuestionDate", typeof(string));
			result.Columns.Add("StudentName", typeof(string));
			result.Columns.Add("AnswerScore", typeof(int));
			result.Columns.Add("QuestionText", typeof(string));
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = (
						"SELECT questionDate, studentName, answerScore, questionText " +
						"FROM Question, Student WHERE classId=@classId " +
						"AND Question.studentId = Student.studentId;");
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@classId", classId);
					using (SQLiteDataReader reader = cmd.ExecuteReader()) {
						while (reader.Read()) {
							DataRow row = result.NewRow();
							row["QuestionDate"] = reader.GetString(0);
							row["StudentName"] = reader.GetString(1);
							row["AnswerScore"] = reader.GetInt32(2);
							row["QuestionText"] = reader.GetString(3);
							result.Rows.Add(row);
						}
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.GetQuestionResultTable: " + e);
				}
			}
			return result;
		}

		/// <summary>
		///   指定された授業IDの結果を全消去する。
		/// </summary>
		public void ResetResults(int classId) {
			using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
				try {
					cmd.CommandText = (
						"DELETE FROM Question WHERE studentID IN " +
						"(SELECT studentId FROM Student WHERE classId=@classId);");
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@classId", classId);
					cmd.ExecuteNonQuery();
					if (RecordUpdated != null) {
						RecordUpdated(this, new ClassIdEventArgs(classId));
					}
				} catch (SQLiteException e) {
					Console.WriteLine("Database.ResetResults: " + e);
				}
			}
		}

		/// <summary>
		///   指定された授業IDの結果をCSVファイルとして出力する。
		/// </summary>
		public void ExportResultsToCSV(int classId, string path) {
			using (StreamWriter writer = new StreamWriter(path)) {
				using (SQLiteCommand cmd = new SQLiteCommand(this.connection)) {
					try {
						cmd.CommandText = (
							"SELECT questionDate, studentName, answerScore, questionText " +
							"FROM Question, Student WHERE Student.classId=@classId " +
							"AND Question.studentId = Student.studentId;");
						cmd.Prepare();
						cmd.Parameters.AddWithValue("@classId", classId);
						using (SQLiteDataReader reader = cmd.ExecuteReader()) {
							while (reader.Read()) {
								string questionDate = reader.GetString(0);
								string studentName = reader.GetString(1);
								int answerScore = reader.GetInt32(2);
								string questionText = reader.GetString(3);
								string line = string.Format("{0},{1},{2},{3}",
									questionDate, studentName, answerScore, questionText);
								writer.WriteLine(line);
							}
						}
					} catch (SQLiteException e) {
						Console.WriteLine("Database.ExportResultsToCSV: " + e);
					}
				}
			}
		}
	}

}
