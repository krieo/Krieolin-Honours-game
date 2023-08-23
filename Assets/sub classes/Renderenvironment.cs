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
    /// This class is responsible for creating objects dynamically 
    /// and placing them in the game world
    /// </summary>
    public class RenderEnvironment : MonoBehaviour
    {
        public GameObject[] Floor;
        public float spawnRate = 1f;
        public float timer = 0;
        public float heightOffSet = 10;
        private GameObject lastSpawnedObject;
        public float spawnPositionXOffSet = 10;
        public float spawnPositionYOffSet = 10;
        public int timeToStop = 20;
        public int timeToStopCounter = 0;
        

        //These methods are responsible for the neural networks
        //and logistic regression algorithm 
        public TruthNeuralNetwork trueNetwork = null;
        public FalseNeuralNetwork falseNetwork = null;
        public LogisticRegressionModel logisticRegressionModel = null;


        /// <summary>
        /// Start is called before the first frame update
        /// this is to get the rightmost position of the prefab 
        /// so that the items do not overlap with each other
        /// </summary>
        void Start()
        {
            // Calculate the initial spawn position offset
            Bounds prefabBounds = GetPrefabBounds(Floor[0]);
            spawnPositionYOffSet = prefabBounds.center.y - prefabBounds.extents.y;
            timeToStop = 4000;
            timeToStopCounter = 0;
        }

        /* old update method
            /// <summary>
            /// update is called once a frame
            /// the game objects spawn within a fixed time
            /// dynamically in the game
            /// </summary>
            void Update()
            {
                if (timer < spawnRate)
                {
                    timer = timer + Time.deltaTime;
                }
                else
                {
                    //creates a dynamic object
                    spawnFloor();
                    timer = 0;
                }
            }
        */

        /// <summary>
        /// update is called once a frame
        /// the game objects spawn within a fixed time
        /// dynamically in the game
        /// </summary>
        void Update()
        {
            if (timeToStopCounter > timeToStop)
            {
                return;
            }
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                //creates a dynamic object
                spawnFloor();
                timer = 0;
            }
            timeToStopCounter++;
        }

        /// <summary>
        /// This method dynamically spawns a floor with proper spacing
        /// </summary>
        public void spawnFloor()
        {
            // Calculate the spawn position of the next prefab
            Vector3 spawnPosition;
            int floorNumber = Random.Range(0, Floor.Length);
            if (lastSpawnedObject == null)
            {
                spawnPosition = new Vector3(Floor[floorNumber].transform.position.x, spawnPositionYOffSet, 0);
            }
            else
            {
                Bounds prefabBounds = GetPrefabBounds(lastSpawnedObject);
                float xSpawnOffset = prefabBounds.size.x + spawnPositionXOffSet;
                spawnPosition = new Vector3(lastSpawnedObject.transform.position.x + xSpawnOffset, spawnPositionYOffSet, 0);
            }

            // Spawn the next prefab
            lastSpawnedObject = Instantiate(Floor[floorNumber], spawnPosition, transform.rotation);
        }

        /// <summary>
        /// Function to get the bounds of the instantiated prefab
        /// </summary>
        /// <param name="prefab"></param>
        /// <returns></returns>
        Bounds GetPrefabBounds(GameObject prefab)
        {
            Renderer prefabRenderer = prefab.GetComponent<Renderer>();

            if (prefabRenderer != null)
            {
                return prefabRenderer.bounds;
            }
            else
            {
                // If the prefab doesn't have a renderer, calculate the bounds using all child renderers
                Renderer[] childRenderers = prefab.GetComponentsInChildren<Renderer>();
                if (childRenderers.Length > 0)
                {
                    Bounds bounds = childRenderers[0].bounds;
                    for (int i = 1; i < childRenderers.Length; i++)
                    {
                        bounds.Encapsulate(childRenderers[i].bounds);
                    }
                    return bounds;
                }
            }

            // Return an empty bounds if no renderer found
            return new Bounds();
        }
    }

}
