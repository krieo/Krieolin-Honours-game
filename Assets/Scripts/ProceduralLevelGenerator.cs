using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This class is responsible for creating objects dynamically 
/// and placing them in the game world using evolutanary algorithms
/// </summary>
public class ProceduralLevleGenerator : MonoBehaviour
{
    public GameObject[] Floor; //will contain gameObjects to define half of the population
    public GameObject[] Floor2; //will contain gameObjects to define the other half of the population
    public GameObject[] FitnessAccessor; ////will contain gameObjects to define what the idea fitness should look like
    public float spawnRate = 0.5f;
    public float timer = 0;
    public float heightOffSet = 0;
    private GameObject lastSpawnedObject;
    public float spawnPositionXOffSet = 0;
    public float spawnPositionYOffSet = 0;
    public GameObject player;
    public int timeToStop = 0;
    public int timeToStopCounter =0;
    
    //This will create 5 different populations of gameObjects
    private List<GameObject> population1;
    private List<GameObject> population2;
    private List<GameObject> population3;
    private List<GameObject> population4;
    private List<GameObject> population5;

    private List<List<GameObject>> entirePopulation;

    /// <summary>
    /// Start is called before the first frame update
    /// this is to get the rightmost position of the prefab 
    /// so that the items do not overlap with each other
    /// </summary>
    void Start()
    {
        // Calculate the initial spawn position offset
        Bounds prefabBounds = GetPrefabBounds(Floor2[0]);
        spawnPositionYOffSet = prefabBounds.center.y - prefabBounds.extents.y;
        initializePopulation();
        
    }

    /// <summary>
    /// this method adds the 5 members of the population to the list
    /// </summary>
    private List<List<GameObject>> AddPopulationToList()
    {

        var population = new List<List<GameObject>>();
        population.Add(population1);
        population.Add(population2);
        population.Add(population3);
        population.Add(population4);
        population.Add(population5);

        return population;
    }

    /// <summary>
    /// This method initialises the population for the 5 sequences
    /// </summary>
    private void initializePopulation()
    {
        population1 = new List<GameObject>();
        population2 = new List<GameObject>();
        population3 = new List<GameObject>();
        population4 = new List<GameObject>();
        population5 = new List<GameObject>();

        //this adds a random DNA sequence in the array for the game objects
        //i decided for each object to contain 10 DNA sequences 5 from each floor item
        for (int i = 0; i < 5; i++)
        {


            population1.Add(Floor[Random.Range(0, Floor.Length)]);
            population2.Add(Floor[Random.Range(0, Floor.Length)]);
            population3.Add(Floor[Random.Range(0, Floor.Length)]);
            population4.Add(Floor[Random.Range(0, Floor.Length)]);
            population5.Add(Floor[Random.Range(0, Floor.Length)]);
        }


        for (int i = 0; i < 5; i++)
        {
            population1.Add(Floor2[Random.Range(0, Floor2.Length)]);
            population2.Add(Floor2[Random.Range(0, Floor2.Length)]);
            population3.Add(Floor2[Random.Range(0, Floor2.Length)]);
            population4.Add(Floor2[Random.Range(0, Floor2.Length)]);
            population5.Add(Floor2[Random.Range(0, Floor2.Length)]);

        }

        //this adds all 5 members of the population to the list variable for easy referencing
        entirePopulation = AddPopulationToList();
    }

    /// <summary>
    /// This method performs the mutation of the DNA sequence
    /// to find the most optimal member of the population in this
    /// instance it finds the most optimal game instance that best
    /// matches the fitness gameobject
    /// </summary>
    /// <returns></returns>
    private GameObject[] GeneticAlgorithm(List<List<GameObject>> population)
    {
        List<int[]> FitnessLocationsForPopulation = new List<int[]>();
        List<int> FitnessScoresForPopulation = new List<int>();
        //this section calculates the weights of each member in the population
        foreach (var members in population)
        {
            FitnessLocationsForPopulation.Add(FindFitness(members.ToArray()));
            FitnessScoresForPopulation.Add(CalculateFitness(FindFitness(members.ToArray())));
        }

        //this section gets the most fit parents from the list
        List<GameObject> parent1 = new List<GameObject>();
        List<GameObject> parent2 = new List<GameObject>();

        //find the most fit and second most fit
        int indexOfMax = 0;
        int indexOfMax2 = 0;
        foreach (var i in FitnessScoresForPopulation)
        {
            if (i == FitnessScoresForPopulation.Max())
            {

                break;
            }
            indexOfMax++;
        }

        FitnessScoresForPopulation.Remove(FitnessScoresForPopulation.Max());

        foreach (var i in FitnessScoresForPopulation)
        {
            if (i == FitnessScoresForPopulation.Max())
            {

                break;
            }
            indexOfMax2++;
        }

        parent1 = population.ElementAt(indexOfMax);
        parent2 = population.ElementAt(indexOfMax2);

        //this section reproduces the parents and adds it to the child
        List<GameObject> child = new List<GameObject>();
        child = Reproduce(parent1.ToArray(), parent2.ToArray()).ToList();
        //this has a small probability to mutate the object
        child = Mutate(child.ToArray()).ToList();

        return child.ToArray();
    }

    /// <summary>
    /// This method mutates the individual if some random probabilty is selected
    /// based on the fitness of the overall gameobject
    /// </summary>
    /// <param name="individual"></param>
    /// <returns></returns>
    private GameObject[] Mutate(GameObject[] individual)
    {
        int[] fitPoints = FindFitness(individual);
        int fitnessScore = CalculateFitness(fitPoints);
        //a 50% chance
        if (fitnessScore < 5)
        {
            foreach (int i in fitPoints)
            {
                if (i == 0)
                {
                    int chanceToMutate = Random.Range(0, 10);
                    //i allocated a 20% chance to mutate
                    if (chanceToMutate < 2)
                    {
                        individual[i] = FitnessAccessor[i];
                    }
                }
            }
        };
        return individual;
    }

    /// <summary>
    /// This method finds the fitness sequences and returns it as
    /// an array of 1's and 0's from the overall fitness 
    /// 1 = item is there
    /// 0 = item is not there
    /// </summary>
    /// <param name="population"></param>
    /// <returns></returns>
    private int[] FindFitness(GameObject[] population)
    {
        int[] location = new int[population.Length];
        int i = 0;
        foreach (var item in population)
        {
            location[i] = 0;
            if (FitnessAccessor.Contains(item))
            {
                location[i] = 1;
            }
            i++;
        }

        return location;
    }


    /// <summary>
    /// This method calculates a neumarical value for the fitness
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    private int CalculateFitness(int[] location)
    {
        int i = 0;
        foreach (var item in location)
        {
            i++;
        }

        return i;
    }
    /// <summary>
    /// This method modifies the parents DNA to produce a new offspring
    /// </summary>
    /// <returns> a new child object</returns>
    private GameObject[] Reproduce(GameObject[] parent1, GameObject[] parent2)
    {
        GameObject[] newChild = new GameObject[parent1.Length]; // the lengths are standard

        for (int i = 0; i < 5; i++)
        {
            newChild[i] = parent1[Random.Range(0, parent1.Length)];
        }

        for (int i = 5; i < 10; i++)
        {
            newChild[i] = parent2[Random.Range(0, parent2.Length)];
        }
        return newChild;
    }

    
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
            //spawnFloor();
            spawnEvolutionaryAll();
            timer = 0;
        }
        timeToStopCounter++;
    }
    


    


    /// <summary>
    /// This is a spawn method that spawns every item in the gameObject[] that the genetic
    /// algorithm produces
    /// </summary>
    private void spawnEvolutionaryAll() 
    {

        GameObject[] toSpawn = GeneticAlgorithm(entirePopulation);
        // Calculate the spawn position of the next prefab
        Vector3 spawnPosition;
        for (int i = 0; i < Floor.Length;i++) 
        {
            if (lastSpawnedObject == null)
            {
                //   spawnPosition = new Vector3(Floor[floorNumber].transform.position.x, spawnPositionYOffSet, 0);

                spawnPosition = new Vector3(toSpawn[i].transform.position.x, spawnPositionYOffSet, 0);
            }
            else
            {
                Bounds prefabBounds = GetPrefabBounds(lastSpawnedObject);
                float xSpawnOffset = prefabBounds.size.x + spawnPositionXOffSet;
                spawnPosition = new Vector3(lastSpawnedObject.transform.position.x + xSpawnOffset, spawnPositionYOffSet, 0);
            }

            // Spawn the next prefab
            lastSpawnedObject = Instantiate(toSpawn[i], spawnPosition, transform.rotation);


        }


    }

    /// <summary>
    /// This method dynamically spawns a floor with proper spacing
    /// </summary>
    public void spawnFloor()
    {
        GameObject[] toSpawn = GeneticAlgorithm(entirePopulation);
        // Calculate the spawn position of the next prefab
        Vector3 spawnPosition;
        int floorNumber = Random.Range(0, Floor.Length);
        if (lastSpawnedObject == null)
        {
            //   spawnPosition = new Vector3(Floor[floorNumber].transform.position.x, spawnPositionYOffSet, 0);

            spawnPosition = new Vector3(toSpawn[floorNumber].transform.position.x, spawnPositionYOffSet, 0);
        }
        else
        {
            Bounds prefabBounds = GetPrefabBounds(lastSpawnedObject);
            float xSpawnOffset = prefabBounds.size.x + spawnPositionXOffSet;
            spawnPosition = new Vector3(lastSpawnedObject.transform.position.x + xSpawnOffset, spawnPositionYOffSet, 0);
        }

        // Spawn the next prefab
        lastSpawnedObject = Instantiate(toSpawn[floorNumber], spawnPosition, transform.rotation);
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
