using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToUser : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ToUserEdit()
	{
		SceneManager.LoadScene("AddUser");
	}
<<<<<<< HEAD
=======
    public void ToUserRemove()
    {
        SceneManager.LoadScene("RemoveUser");
    }
    public void ToWordAdd()
    {
        SceneManager.LoadScene("AddWord");
    }
>>>>>>> bd3fc48caf272e42de70db7cc91b5491550365dd


}
