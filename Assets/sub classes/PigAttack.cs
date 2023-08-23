using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.sub_classes
{

    /// <summary>
    /// This script is responsible for the attack from the pig character
    /// </summary>
    public class PigAttack : MonoBehaviour
    {
        public AudioSource audioAttack;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// This method overrides the on trigger method
        /// it checks if the item standing on is a player
        /// and destroys it
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                audioAttack.Play();
                //Destroy(collision.gameObject);
                DestroyObjectAndParent(collision.gameObject);


            }
        }

        /// <summary>
        /// This method checks if the gameobject has a parent object so that
        /// it will destroy its children as well, its better to use this and check
        /// rather than the plain destroy method
        /// </summary>
        /// <param name="obj"></param>
        private void DestroyObjectAndParent(GameObject obj)
        {
            if (obj.transform.parent != null)
            {
                string parentName = obj.transform.parent.gameObject.name;
                if (parentName != "Player")
                {
                    Destroy(obj.transform.parent.gameObject);
                }
                else
                {
                    Destroy(obj);
                }
            }
            else
            {
                Destroy(obj);
            }
        }
    }

}
