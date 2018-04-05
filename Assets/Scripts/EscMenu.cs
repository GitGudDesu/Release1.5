using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour {

    private bool isShowed = false;
    private float transition = 0.0f;

    public GameObject pausemenuUI;
    public static bool GameisPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void ResumeGame()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
