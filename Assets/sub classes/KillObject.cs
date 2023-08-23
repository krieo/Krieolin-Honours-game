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
    /// This script is responsible for killing objects
    /// </summary>
    public class KillObject : MonoBehaviour
    {
        public Animator myAnimator;
        private BoxCollider2D boxCollider; // Reference to the 2D Box Collider component

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        void Start()
        {
            myAnimator = GetComponent<Animator>();

            // Add 2D Box Collider to the current object
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.isTrigger = true; // Set the collider as a trigger

            // Disable the physical collision with other objects
            boxCollider.usedByEffector = false;
            boxCollider.usedByComposite = false;
            boxCollider.usedByEffector = false;
            boxCollider.usedByComposite = false;
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {

        }

        /// <summary>
        /// This overrides the ontrigger method
        /// it detects if the player attacks and it connects
        /// and loads the correct animation for it
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Attack"))
            {
                myAnimator.SetBool("isKilled", true);
                gameObject.tag = "DeadObject";

                StartCoroutine(DelayedDestroy());
            }
        }

        /// <summary>
        /// This method destroys the game object after some delay
        /// </summary>
        /// <returns></returns>
        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(0.1f); 

            Destroy(gameObject); // Destroy the object after the delay
        }
    }

}
