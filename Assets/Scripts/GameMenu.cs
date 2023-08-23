using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This class is responsible for the game menu buttons
/// </summary>
public class GameMenu : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// This loads level 1
    /// </summary>
    public void level1() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    /// <summary>
    /// This loads level 2
    /// </summary>
    public void level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


    /// <summary>
    /// This loads level 3
    /// </summary>
    public void level3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
