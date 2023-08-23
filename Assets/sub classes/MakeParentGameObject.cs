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
    /// This script is responsible for setting the 
    /// current game object as the parent
    /// </summary>
    public class MakeParentGameObject : MonoBehaviour
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
        /// This overrides the on collision method to ensure the player moves with the game object
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.SetParent(transform, true);
            }
        }


        /// <summary>
        /// This overrides the the exit colission method to ensure the player move with other moving items
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.SetParent(null);
            }
        }
    }

}
