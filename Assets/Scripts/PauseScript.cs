using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is responsible for the pause
/// functionailty when the P key is pressed
/// or the return home functionality when
/// the escape key is pressed
/// </summary>
public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseScreen;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
           
    }

    /// <summary>
    /// Update is called once per frame
    /// this checks if the P key is pressed and
    /// then loads the home screen menu
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           // levelPause();
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelPause();
            //TogglePause();
        }
    }


    /// <summary>
    /// This loads level 0 the game menu
    /// </summary>
    public void levelPause()
    {
        SceneManager.LoadScene(0);
    }


  /// <summary>
  /// This method is used to pause the game
  /// </summary>
   public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    /// <summary>
    /// This method implements the pause functionality
    /// right now it stops the games time so that everything
    /// is frozen in place, not sure if it might cause bugs
    /// </summary>
    void PauseGame()
    {
        Time.timeScale = 0f; // Set the time scale to 0 to pause the game
        pauseScreen.SetActive(true);
        Debug.Log("Game Paused");

       
    }

    /// <summary>
    /// This method is used to resume the game
    /// </summary>
    void ResumeGame()
    {
        Time.timeScale = 1f; // Set the time scale back to 1 to resume the game
        pauseScreen.SetActive(false);
        Debug.Log("Game Resumed");
       
    }

}
