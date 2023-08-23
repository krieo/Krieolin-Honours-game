using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is responsible for various
/// other items not directly related to the player
/// </summary>
public class PlayerStatsScript : MonoBehaviour
{ 
    public Animator animator;
    public Rigidbody2D rigidBody;
    public AudioSource audioDeath;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// This overrides the collision detection to detect for traps
    /// if one is detected it kills the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap")) 
        { 
        killPlayer();
        audioDeath.Play();
        }
    }


    /// <summary>
    /// This method kills the player
    /// and makes them unable to move 
    /// after they have been killed
    /// </summary>
    private void killPlayer() 
    {
        //sets the death trigger in the animation 
        animator.SetTrigger("death");
        //this changes the dynamic body to static so it is unmoveable
        //rigidBody.bodyType = RigidbodyType2D.Static;
    }

    /// <summary>
    /// This method will reload the level once the player has been killed
    /// this method gets called within the death animation for a player character
    /// </summary>
    private void ReloadLevel() 
    {
        //this will reload the current scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
