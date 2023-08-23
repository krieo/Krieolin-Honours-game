using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This script is used specifically for
/// the plant object to allow for movement
/// for the plant items
/// </summary>
public class plantPathFinder : MonoBehaviour
{
    public GameObject[] pathPoints;
    public int currentPathIndex = 0;
    public float movementSpeed = 2f;
    public SpriteRenderer spriteRenderer;

    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
        pathPoints = new GameObject[pathPoints.Length];
    }


    /// <summary>
    /// This will get the values of the gameObject indexes and move the main object
    /// around these various objects
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Vector2.Distance(pathPoints[currentPathIndex].transform.position, transform.position) < .1f)
            {
                currentPathIndex++;
                // flipSprites();

                if (currentPathIndex >= pathPoints.Length)
                {
                    currentPathIndex = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, pathPoints[currentPathIndex].transform.position, Time.deltaTime * movementSpeed);

        }
        catch (Exception e)
        {

            Debug.Log(e.ToString());
            Debug.Log(currentPathIndex);
            Debug.Log(pathPoints.Length);

        }

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
