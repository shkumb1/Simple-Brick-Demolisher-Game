using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        if (PlayerPrefs.GetString("HIGHSCORENAME") != "")
        {
            highScoreText.text = "High Score Set by: " + PlayerPrefs.GetString("HIGHSCORENAME") + "," + " score: " + PlayerPrefs.GetInt("HIGHSCORE");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Button Pressed");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
