using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EvolutionaryMovement : MonoBehaviour
    {
        private AgentManager agentManager;
        private int maximumAmountOfOranges = 20;
        private int player1Death = 0;
        private int player2Death = 0;
        private int player3Death = 0;
        private int player4Death = 0;
        private int player5Death = 0;
        private int numberOfMaximumMoves = 20;

        //this represents the inital population and their move sets
        // 0 = idle
        // 1 = move left
        // 2 = move right 
        // 3 = jump
        private List<List<int>> population = new List<List<int>>();
        private List<int> genome1 = new List<int>();
        private List<int> genome2 = new List<int>();
        private List<int> genome3 = new List<int>();
        private List<int> genome4 = new List<int>();
        private List<int> genome5 = new List<int>();

        void Start()
        {
            //this sets the player death count
            agentManager = FindObjectOfType<AgentManager>();
            player1Death = agentManager.player1GetDeathCount();
            player2Death = agentManager.player2GetDeathCount();
            player3Death = agentManager.player3GetDeathCount();
            player4Death = agentManager.player4GetDeathCount();
            player5Death = agentManager.player5GetDeathCount();

            //this adds the genomes to the population
            //and randomly assigns them a move set
            genome1 = generateRandomMoveSet(numberOfMaximumMoves);
            population.Add(genome1);
            genome2 = generateRandomMoveSet(numberOfMaximumMoves);
            population.Add(genome2);
            genome3 = generateRandomMoveSet(numberOfMaximumMoves);
            population.Add(genome3);
            genome4 = generateRandomMoveSet(numberOfMaximumMoves);
            population.Add(genome4);
            genome5 = generateRandomMoveSet(numberOfMaximumMoves);
            population.Add(genome5);

        }

        void Update()
        {
            movePlayers();

            checkIfPlayer1Died();
            checkIfPlayer2Died();
            checkIfPlayer3Died();
            checkIfPlayer4Died();
            checkIfPlayer5Died();


        }


        /// <summary>
        /// This method is responsible for converting the numbers to player movements
        /// </summary>
        private void movePlayers() 
        {
            foreach (int item in genome1)
            {
                Debug.Log(item);
                if (item == 0)
                {
                    agentManager.player1Idle();
                }
                if (item == 1)
                {
                    agentManager.player1MoveLeft();
                }
                if (item == 2)
                {
                    agentManager.player1MoveRight();
                }
                if (item == 3)
                {
                    agentManager.player1MoveUp();
                }

            }

            foreach (int item in genome2)
            {

                if (item == 0)
                {
                    agentManager.player2Idle();
                }
                if (item == 1)
                {
                    agentManager.player2MoveLeft();
                }
                if (item == 2)
                {
                    agentManager.player2MoveRight();
                }
                if (item == 3)
                {
                    agentManager.player2MoveUp();
                }



            }


            foreach (int item in genome3)
            {
                Debug.Log(item);
                if (item == 0)
                {
                    agentManager.player3Idle();
                }
                if (item == 1)
                {
                    agentManager.player3MoveLeft();
                }
                if (item == 2)
                {
                    agentManager.player3MoveRight();
                }
                if (item == 3)
                {
                    agentManager.player3MoveUp();
                }

            }

            foreach (int item in genome4)
            {
                Debug.Log(item);
                if (item == 0)
                {
                    agentManager.player4Idle();
                }
                if (item == 1)
                {
                    agentManager.player4MoveLeft();
                }
                if (item == 2)
                {
                    agentManager.player4MoveRight();
                }
                if (item == 3)
                {
                    agentManager.player4MoveUp();
                }

            }

            foreach (int item in genome5)
            {
                Debug.Log(item);
                if (item == 0)
                {
                    agentManager.player5Idle();
                }
                if (item == 1)
                {
                    agentManager.player5MoveLeft();
                }
                if (item == 2)
                {
                    agentManager.player5MoveRight();
                }
                if (item == 3)
                {
                    agentManager.player5MoveUp();
                }

            }

        }



        /// <summary>
        /// This method returns a list of randomly generated moves
        /// </summary>
        /// <param name="numberOfSteps"></param>
        /// <returns></returns>
        public List<int> generateRandomMoveSet(int numberOfSteps) 
        { 
        
            List<int> list = new List<int>();

            for (int i = 0; i < numberOfSteps; i++) 
            { 
            list.Add(getRandomMove());
            }
        
            return list;
        }


        /// <summary>
        /// This method returns a random number from 0 to 4
        /// that will each represent a random move
        /// 0 = idle
        /// 1 = move left
        /// 2 = move right
        /// 3 = jump
        /// </summary>
        /// <returns></returns>
        public int getRandomMove() 
        {
            return UnityEngine.Random.Range(0, 4);
        }

        /// <summary>
        /// This method checks if the player has died and 
        /// updates the current death counter for that player
        /// and then calculates a fitness to determine how 
        /// many oranges a player has collected before they died
        /// </summary>
        private void checkIfPlayer1Died()
        {
            
            if (agentManager.player1GetDeathCount() > player1Death)
            {
                player1Death = agentManager.player1GetDeathCount();
                CalculateFitness(agentManager.player1GetOrangeCount());
            }

        }

        /// <summary>
        /// This method checks if the player has died and 
        /// updates the current death counter for that player
        /// and then calculates a fitness to determine how 
        /// many oranges a player has collected before they died
        /// </summary>
        private void checkIfPlayer2Died()
        {

      
            if (agentManager.player2GetDeathCount() > player2Death)
            {
                player2Death = agentManager.player2GetDeathCount();
                CalculateFitness(agentManager.player2GetOrangeCount());
            }


        }


        /// <summary>
        /// This method checks if the player has died and 
        /// updates the current death counter for that player
        /// and then calculates a fitness to determine how 
        /// many oranges a player has collected before they died
        /// </summary>
        private void checkIfPlayer3Died()
        {


            if (agentManager.player3GetDeathCount() > player3Death)
            {
                player3Death = agentManager.player3GetDeathCount();
                CalculateFitness(agentManager.player3GetOrangeCount());
            }

         

        }

        /// <summary>
        /// This method checks if the player has died and 
        /// updates the current death counter for that player
        /// and then calculates a fitness to determine how 
        /// many oranges a player has collected before they died
        /// </summary>
        private void checkIfPlayer4Died()
        {

        

            if (agentManager.player4GetDeathCount() > player4Death)
            {
                player4Death = agentManager.player4GetDeathCount();
                CalculateFitness(agentManager.player4GetOrangeCount());
            }

         

        }

        /// <summary>
        /// This method checks if the player has died and 
        /// updates the current death counter for that player
        /// and then calculates a fitness to determine how 
        /// many oranges a player has collected before they died
        /// </summary>
        private void checkIfPlayer5Died()
        {

            if (agentManager.player5GetDeathCount() > player5Death)
            {
                player5Death = agentManager.player5GetDeathCount();
                CalculateFitness(agentManager.player5GetOrangeCount());
            }

        }



        /// <summary>
        /// This is the fitness function.
        /// It calculates a fitness value between 0 and 1 for the 
        /// number of oranges collected; those who collect more oranges
        /// will be closer to 1.
        /// </summary>
        /// <param name="orangesCollected"></param>
        /// <returns></returns>
        public float CalculateFitness(int orangesCollected)
        {
            float fitness = (float)orangesCollected / maximumAmountOfOranges;
            return fitness;
        }


    }
}
