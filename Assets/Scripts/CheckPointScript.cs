using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is responsible for the checkpoints in the game
/// as of current upon reaching a checkpoint it sends the player 
/// to the next level
/// </summary>
public class CheckPointScript : MonoBehaviour
{
    public AudioSource audioCheckPoint;

    /// <summary>
    /// start is called before the first update frame
    /// </summary>
    void Start()
    {
        audioCheckPoint = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// This method overrides the default ontrigger method
    /// to detect if the player has collided with the object
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
        audioCheckPoint.Play();
            //this is used to add a delay before calling the method
            //so that the audio can play 
            Invoke("reacheCheckPoint",2f);
            //reacheCheckPoint();
        }
    }


    /// <summary>
    /// This method works as a reach checkpoint method
    /// </summary>
    public void reacheCheckPoint() 
    {
      //  if (SceneManager.GetActiveScene().buildIndex >= 2)
       // {
        //    SceneManager.LoadScene(1);
      //  }
      //  else 
      //  {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      //  }
           //might have to change this so that it loops to the start
    }
}
