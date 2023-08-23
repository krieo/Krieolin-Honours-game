using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script allows for items to be collected such as oranges
/// </summary>
public class ItemCollectionScript : MonoBehaviour
{
    private int orangesDestroyed = 0;
    public Text myText;
    public AudioSource audioCollect;

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
    /// This overrides the original onTrigger event
    /// it checks if the player connects with an orange and collects it
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this checks if the game object that the player collided with is an orange
        //i.e has the orange tag and destroys it
        if (collision.gameObject.CompareTag("Orange"))
        {
            Destroy(collision.gameObject);
            orangesDestroyed++;
            myText.text = "Orange's collected : " + orangesDestroyed;
            audioCollect.Play();
        }
    }
}
