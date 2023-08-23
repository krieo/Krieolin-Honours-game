using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for the player
/// detection from the enemy ( mainly the pig enemy)
/// </summary>
public class PlayerDetectionScript : MonoBehaviour
{
    public GameObject enemy;
    private float originalY;
    private bool hitTrigger = false;
    private GameObject player;

    /// <summary>
    /// This method is called before the game starts
    /// </summary>
    private void Start()
    {
        originalY = transform.position.y;
    }

    /// <summary>
    /// This method overrides the on trigger method
    /// it detects if a player is within the observable 
    /// range and persues it
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hitTrigger = true;
            player = collision.gameObject;

            Vector3 newPosition = collision.transform.position;
            newPosition.y = originalY; // Use the original y-coordinate
            transform.position = newPosition;
            if (enemy != null)
            {
                enemy.GetComponent<pathFinder>().movementSpeed = 10f;
            }
        }
    }



    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (hitTrigger == true && player != null)
        {
            Vector3 newPosition = player.transform.position;
            newPosition.y = originalY;
            transform.position = newPosition;
        }
    }
}