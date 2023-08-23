using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to help objects 
/// find a path from coodinates in game
/// so that they don't go out of bounds
/// for the player
/// </summary>
public class pathFinder : MonoBehaviour
{
    public GameObject[] pathPoints;
    public int currentPathIndex = 0;
    public float movementSpeed = 2f;
    public SpriteRenderer spriteRenderer;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {

    }


    /// <summary>
    /// This will get the values of the gameObject indexes and move the main object
    /// around these various objects
    /// </summary>
    void Update()
    {
        if (Vector2.Distance(pathPoints[currentPathIndex].transform.position, transform.position) < .1f)
        {
            currentPathIndex++;
            flipSprites();

            if (currentPathIndex >= pathPoints.Length)
            {
                currentPathIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, pathPoints[currentPathIndex].transform.position, Time.deltaTime * movementSpeed);
    }

    /// <summary>
    /// This method is responsible for flipping the sprite
    /// </summary>
    private void flipSprites()
    {
        if (spriteRenderer != null)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
            else if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

}
