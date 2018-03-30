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
    //create array lists for the DB
    private ArrayList userList = new ArrayList();
	private ArrayList teacherList = new ArrayList();

    public Button LoginButton;
    void Start ()
		{
            var input = GameObject.Find("InputField").GetComponent<InputField>();
			var se= new InputField.SubmitEvent();
			se.AddListener(CheckName);
			input.onEndEdit = se;

			//or simply use the line below, 
			//input.onEndEdit.AddListener(CheckName);  // This also works


		}

		private void CheckName(string arg0)
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
			
		if (userList.Contains (arg0)) {
            LoginButton.interactable = true;
		} else if (teacherList.Contains (arg0)) {
			SceneManager.LoadScene("TeacherMenu");
		}
		else {
            SceneManager.LoadScene("Login");
        }
		}
}

