using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for handling the player
/// out of bounds movement
/// </summary>
public class OutOfBounds : MonoBehaviour
{
    /// <summary>
    /// This ensures if the player goes out of bounds
    /// they die
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
           collision.GetComponent<Animator>().SetTrigger("death");
        }
        
    }

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
}
