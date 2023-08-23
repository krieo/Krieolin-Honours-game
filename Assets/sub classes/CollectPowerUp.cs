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
    using UnityEngine.UI;

    /// <summary>
    /// This script allows for items to be collected
    /// </summary>
    public class CollectPowerUp : MonoBehaviour
    {
        private int powerUpsCollected = 0;
        public Text myText;
        public AudioSource audioCollect;

        /// <summary>
        /// This constructor is used to add power ups
        /// </summary>
        /// <param name="powerUpsCollected"></param>
        public CollectPowerUp(int powerUpsCollected)
        {
            this.powerUpsCollected = powerUpsCollected;
        }

        /// <summary>
        /// This method is used to get the power ups
        /// </summary>
        /// <returns></returns>
        public int getPowerup() 
        { 
        return powerUpsCollected;
        }

        /// <summary>
        /// This method can be used to set the power ups
        /// </summary>
        /// <param name="powerup"></param>
        public void setPowerUps(int powerup)
        {
            this.powerUpsCollected = powerup;
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

        /// <summary>
        /// This overrides the original onTrigger event
        /// it checks if the player connects with an power up and collects it
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //this checks if the game object that the player collided with is an power up
            //i.e has the power up tag

            if (collision.gameObject.CompareTag("PowerUp"))
            {               
                powerUpsCollected++;
                myText.text = "Power up : " + powerUpsCollected;
                audioCollect.Play();
            }
        }
    }

}
