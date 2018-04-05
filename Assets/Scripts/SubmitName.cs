using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.SceneManagement;

public class SubmitName : MonoBehaviour
	{
<<<<<<< HEAD
	//create array lists for the DB
	private ArrayList userList = new ArrayList();
	private ArrayList teacherList = new ArrayList();
	private static int currTeachID = 0;
	private static int currStuID = 0;
<<<<<<< HEAD
=======
    private static string stuGrade;
>>>>>>> bd3fc48caf272e42de70db7cc91b5491550365dd


	public Button LoginButton;
		void Start ()
=======
    //create array lists for the DB
    private ArrayList userList = new ArrayList();
    public Button LoginButton;
    void Start ()
>>>>>>> parent of a43b7f2... Pause Option and Esc Menu added
		{
            var input = GameObject.Find("InputField").GetComponent<InputField>();
			var se= new InputField.SubmitEvent();
			se.AddListener(CheckName);
			input.onEndEdit = se;

			//or simply use the line below, 
			//input.onEndEdit.AddListener(CheckName);  // This also works


		}

<<<<<<< HEAD
		public static int getTeachID()
<<<<<<< HEAD
		{
			return currTeachID;
		}
		public static int getStuID()
		{
			return currStuID;
		}

		private void CheckName(string arg0)
=======
		{
			return currTeachID;
		}
		public static int getStuID()
		{
			return currStuID;
		}
    public static String getStuGrade()
    {
        return stuGrade;
    }

    private void CheckName(string arg0)
>>>>>>> bd3fc48caf272e42de70db7cc91b5491550365dd
			{


				//direct db connection to where the db is stored in app
				//and open connection
				const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
				IDbConnection dbcon = new SqliteConnection (connectionString);
				dbcon.Open ();

				//create query for user name
				IDbCommand dbcmd = dbcon.CreateCommand ();
				const string sql =
					"SELECT StuUserName " +
					"FROM student";
				dbcmd.CommandText = sql;
				IDataReader reader = dbcmd.ExecuteReader ();
<<<<<<< HEAD

				while (reader.Read()) 
				{
					string user = reader.GetString(0);

					Debug.Log(user);

					userList.Add(user);

				}
				//create query for teacher login
				dbcmd = dbcon.CreateCommand ();
				const string sql2 =
					"SELECT TeachUserName " +
					"FROM teacher";
				dbcmd.CommandText = sql2;
				reader = dbcmd.ExecuteReader ();

				while (reader.Read()) 
				{
					string teacher = reader.GetString(0);

					Debug.Log(teacher);

					teacherList.Add(teacher);

				}
			    //if user is in DB store their userID for later use and allow them to login 
				if (userList.Contains (arg0)) {
				dbcmd = dbcon.CreateCommand();
				const string sql4 =
					"SELECT StuID " +
					"FROM student " +
					"WHERE StuUserName = @arg0";

				dbcmd.Parameters.Add(new SqliteParameter("@arg0", arg0));
				dbcmd.CommandText = sql4;
				reader = dbcmd.ExecuteReader();
				while (reader.Read())
				{
					int stuID = Int32.Parse(reader.GetString(0));

					Debug.Log(currStuID);

					currStuID = stuID;

				}
				LoginButton.interactable = true;
                //if teacher username found, store teacherID for later use and take them to the teacher menu
				} else if (teacherList.Contains (arg0)) {
					dbcmd = dbcon.CreateCommand();
					const string sql3 =
						"SELECT TeachID " +
						"FROM teacher " +
						"WHERE TeachUserName = @arg0";
=======
		private void CheckName(string arg0)
		{
>>>>>>> parent of a43b7f2... Pause Option and Esc Menu added


			//direct db connection to where the db is stored in app
			//and open connection
			const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
			IDbConnection dbcon = new SqliteConnection (connectionString);
			dbcon.Open ();

			//create query for user name
			IDbCommand dbcmd = dbcon.CreateCommand ();
			const string sql =
				"SELECT * " +
				"FROM student";
			dbcmd.CommandText = sql;
			IDataReader reader = dbcmd.ExecuteReader ();

			while (reader.Read()) 
			{
				string user = reader.GetString(2);

				Debug.Log(user);

				userList.Add(user);

=======

				while (reader.Read()) 
				{
					string user = reader.GetString(0);

					Debug.Log(user);

					userList.Add(user);

				}
				//create query for teacher login
				dbcmd = dbcon.CreateCommand ();
				const string sql2 =
					"SELECT TeachUserName " +
					"FROM teacher";
				dbcmd.CommandText = sql2;
				reader = dbcmd.ExecuteReader ();

				while (reader.Read()) 
				{
					string teacher = reader.GetString(0);

					Debug.Log(teacher);

					teacherList.Add(teacher);

				}
			    //if user is in DB store their userID for later use and allow them to login 
				if (userList.Contains (arg0)) {
				dbcmd = dbcon.CreateCommand();
				const string sql4 =
					"SELECT StuID " +
					"FROM student " +
					"WHERE StuUserName = @arg0";

				dbcmd.Parameters.Add(new SqliteParameter("@arg0", arg0));
				dbcmd.CommandText = sql4;
				reader = dbcmd.ExecuteReader();
				while (reader.Read())
				{
					int stuID = Int32.Parse(reader.GetString(0));

					Debug.Log(currStuID);

					currStuID = stuID;

				}
                dbcmd = dbcon.CreateCommand();
                const string sql5 =
                    "SELECT Grade " +
                    "FROM student " +
                    "WHERE StuUserName = @arg0";

                dbcmd.Parameters.Add(new SqliteParameter("@arg0", arg0));
                dbcmd.CommandText = sql4;
                reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    string grade = reader.GetString(0);

                    Debug.Log(grade);

                stuGrade = grade;

                }
            LoginButton.interactable = true;
                //if teacher username found, store teacherID for later use and take them to the teacher menu
				} else if (teacherList.Contains (arg0)) {
					dbcmd = dbcon.CreateCommand();
					const string sql3 =
						"SELECT TeachID " +
						"FROM teacher " +
						"WHERE TeachUserName = @arg0";

					dbcmd.Parameters.Add(new SqliteParameter("@arg0", arg0));
					dbcmd.CommandText = sql3;
					reader = dbcmd.ExecuteReader();
					while (reader.Read())
					{
						int teachID = Int32.Parse(reader.GetString(0));

						Debug.Log(currTeachID);

						currTeachID = teachID;

					}

					SceneManager.LoadScene("TeacherMenu");
				}
				else {
					SceneManager.LoadScene("Login");
				}


>>>>>>> bd3fc48caf272e42de70db7cc91b5491550365dd
			}
			
		if (userList.Contains (arg0)) {
            LoginButton.interactable = true;
		} else {
            SceneManager.LoadScene("Login");
        }
		}
}

