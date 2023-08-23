using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.sub_classes
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// This script is used for linear movements 
    /// so that they don't go out of bounds
    /// for the player
    /// </summary>
    public class SawMotions : MonoBehaviour
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
            //This ensures that only 2 linear motions 
            //are selected
            pathPoints = new GameObject[2];
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

}
