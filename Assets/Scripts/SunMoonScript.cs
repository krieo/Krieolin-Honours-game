using UnityEngine;

/// <summary>
/// This script is responsible for the sun
/// and moon animations on screen to follow
/// the player and move accordingly
/// </summary>
public class SunMoonScript : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject parentObject;
    public float spawnRate = 5f;
    public int currentIndex = 0;
    public float timer = 0;

    private GameObject instantiatedObject;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // Creates a dynamic object
            SpawnObject();
            timer = 0;
        }
    }

    /// <summary>
    /// start is called before the game starts
    /// </summary>
    void Start()
    {
        SpawnObject();
    }

    /// <summary>
    /// This method dynamically spawns a sun/moon
    /// </summary>
    public void SpawnObject()
    {
        if (currentIndex >= gameObjects.Length)
        {
            currentIndex = 0;
        }

        // Destroy the previously instantiated object, if any
        if (instantiatedObject != null)
        {
            Destroy(instantiatedObject);
        }

        instantiatedObject = Instantiate(gameObjects[currentIndex], parentObject.transform.position, transform.rotation);
        instantiatedObject.transform.parent = parentObject.transform;

        currentIndex++;
    }
}
