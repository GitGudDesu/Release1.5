using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.SceneManagement;

public class CreateUser : MonoBehaviour
	{
	public InputField StudentID;  
	public InputField TeacherID;
	public InputField StudentUserName;  
	public InputField FirstName;
	public InputField LastName;  
	public InputField Grade; 

	private int stuID = 0;
	private int teachID = 0;
	private string userName = null;
	private string firstName = null;
	private string lastName = null;
	private string grade = null;

		void Start ()
		{
		//direct db connection to where the db is stored in app
		//and open connection
		const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
		IDbConnection dbcon = new SqliteConnection (connectionString);
		dbcon.Open ();

			
		StudentID.onEndEdit.AddListener(SubmitStudentID);
		TeacherID.onEndEdit.AddListener(SubmitTeacherID);
		StudentUserName.onEndEdit.AddListener(SubmitUserName);
		FirstName.onEndEdit.AddListener(SubmitFirstName);
		LastName.onEndEdit.AddListener(SubmitLastName);
		Grade.onEndEdit.AddListener(SubmitGrade);
		}
			//or simply use the line below, 
			//input.onEndEdit.AddListener(CheckName);  // This also works



		private void SubmitStudentID(string input) {
		stuID = Int32.Parse(input);
		}

		private void SubmitTeacherID(string input) {
		teachID = Int32.Parse(input);
		}

		private void SubmitUserName(string input) {
		userName = input;
		}

		private void SubmitFirstName(string input) {
		firstName = input;
		}

		private void SubmitLastName(string input) {
        lastName = input;
		}

		private void SubmitGrade(string input) {
		grade = input;
		}
	}


