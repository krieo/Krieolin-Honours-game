using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This class is responsible for communicating between the Evolutionary movement and playerAgentMovement classes
    /// </summary>
    public class AgentManager : MonoBehaviour
    {
        private List<playerAgentMovement1> agentMovements1 = new List<playerAgentMovement1>();
        private List<playerAgentMovement2> agentMovements2 = new List<playerAgentMovement2>();
        private List<playerAgentMovement3> agentMovements3 = new List<playerAgentMovement3>();
        private List<playerAgentMovement4> agentMovements4 = new List<playerAgentMovement4>();
        private List<playerAgentMovement5> agentMovements5 = new List<playerAgentMovement5>();

        public float moveLeft = -1;
        public float moveRight = 1;
        /// <summary>
        /// This is a constructor
        /// </summary>
        void Start()
        {
            // Find the parent GameObject
            GameObject playerParent = GameObject.Find("PlayerManagement");

            if (playerParent != null)
            {
                // Get all playerAgentMovement1 components under the parent GameObject
                playerAgentMovement1[] agents1 = playerParent.GetComponentsInChildren<playerAgentMovement1>();
                agentMovements1.AddRange(agents1);

                // Get all playerAgentMovement2 components under the parent GameObject
                playerAgentMovement2[] agents2 = playerParent.GetComponentsInChildren<playerAgentMovement2>();
                agentMovements2.AddRange(agents2);

                // Get all playerAgentMovement3 components under the parent GameObject
                playerAgentMovement3[] agents3 = playerParent.GetComponentsInChildren<playerAgentMovement3>();
                agentMovements3.AddRange(agents3);

                // Get all playerAgentMovement4 components under the parent GameObject
                playerAgentMovement4[] agents4 = playerParent.GetComponentsInChildren<playerAgentMovement4>();
                agentMovements4.AddRange(agents4);

                // Get all playerAgentMovement5 components under the parent GameObject
                playerAgentMovement5[] agents5 = playerParent.GetComponentsInChildren<playerAgentMovement5>();
                agentMovements5.AddRange(agents5);

               
            }
            else
            {
                Debug.LogError("PlayerManagement not found.");
            }
        }

        /// <summary>
        /// This method gets the class for the player and uses a float value
        /// to update their movement speed in the direction, where a positive
        /// value will move to the right at that speed and a negative value
        /// will move to the left at that speed for player 1
        /// </summary>
        /// <param name="newMoveDirection"> this value is used to determine the speed and movement direction</param>
        public void UpdateAgentMovementVariables1(float newMoveDirection)
        {
            foreach (var agent in agentMovements1)
            {
                agent.moveDirection = newMoveDirection;
            }
        }


        /// <summary>
        /// This method gets the class for the player and uses a float value
        /// to update their movement speed in the direction, where a positive
        /// value will move to the right at that speed and a negative value
        /// will move to the left at that speed for player 2
        /// </summary>
        /// <param name="newMoveDirection"> this value is used to determine the speed and movement direction</param>
        public void UpdateAgentMovementVariables2(float newMoveDirection)
        {
            foreach (var agent in agentMovements2)
            {
                agent.moveDirection = newMoveDirection;
            }
        }


        /// <summary>
        /// This method gets the class for the player and uses a float value
        /// to update their movement speed in the direction, where a positive
        /// value will move to the right at that speed and a negative value
        /// will move to the left at that speed for player 3
        /// </summary>
        /// <param name="newMoveDirection"> this value is used to determine the speed and movement direction</param>
        public void UpdateAgentMovementVariables3(float newMoveDirection)
        {
            foreach (var agent in agentMovements3)
            {
                agent.moveDirection = newMoveDirection;
            }
        }


        /// <summary>
        /// This method gets the class for the player and uses a float value
        /// to update their movement speed in the direction, where a positive
        /// value will move to the right at that speed and a negative value
        /// will move to the left at that speed for player 4
        /// </summary>
        /// <param name="newMoveDirection"> this value is used to determine the speed and movement direction</param>
        public void UpdateAgentMovementVariables4(float newMoveDirection)
        {
            foreach (var agent in agentMovements4)
            {
                agent.moveDirection = newMoveDirection;
            }
        }


        /// <summary>
        /// This method gets the class for the player and uses a float value
        /// to update their movement speed in the direction, where a positive
        /// value will move to the right at that speed and a negative value
        /// will move to the left at that speed for player 5
        /// </summary>
        /// <param name="newMoveDirection"> this value is used to determine the speed and movement direction</param>
        public void UpdateAgentMovementVariables5(float newMoveDirection)
        {
            foreach (var agent in agentMovements5)
            {
                agent.moveDirection = newMoveDirection;
            }
        }

        /// <summary>
        /// This method performs a jump for its agent
        /// </summary>
        public void UpdateAgentMovementJump1()
        {
            foreach (var agent in agentMovements1)
            {
                agent.isJump = true ;
            }
        }

        /// <summary>
        /// This method performs a jump for its agent
        /// </summary>
        public void UpdateAgentMovementJump2()
        {
            foreach (var agent in agentMovements2)
            {
                agent.isJump = true;
            }
        }

        /// <summary>
        /// This method performs a jump for its agent
        /// </summary>
        public void UpdateAgentMovementJump3()
        {
            foreach (var agent in agentMovements3)
            {
                agent.isJump = true;
            }
        }


        /// <summary>
        /// This method performs a jump for its agent
        /// </summary>
        public void UpdateAgentMovementJump4()
        {
            foreach (var agent in agentMovements4)
            {
                agent.isJump = true;
            }
        }


        /// <summary>
        /// This method performs a jump for its agent
        /// </summary>
        public void UpdateAgentMovementJump5()
        {
            foreach (var agent in agentMovements5)
            {
                agent.isJump = true;
            }
        }


        /// <summary>
        /// This method sets the orange count to 0
        /// </summary>
        public void UpdateAgentOrangeCount1()
        {
            foreach (var agent in agentMovements1)
            {
                agent.orangesCollected = 0;
            }
        }


        /// <summary>
        /// This method sets the orange count to 0
        /// </summary>
        public void UpdateAgentOrangeCount2()
        {
            foreach (var agent in agentMovements2)
            {
                agent.orangesCollected = 0;
            }
        }


        /// <summary>
        /// This method sets the orange count to 0
        /// </summary>
        public void UpdateAgentOrangeCount3()
        {
            foreach (var agent in agentMovements3)
            {
                agent.orangesCollected = 0;
            }
        }


        /// <summary>
        /// This method sets the orange count to 0
        /// </summary>
        public void UpdateAgentOrangeCount4()
        {
            foreach (var agent in agentMovements4)
            {
                agent.orangesCollected = 0;
            }
        }


        /// <summary>
        /// This method sets the orange count to 0
        /// </summary>
        public void UpdateAgentOrangeCount5()
        {
            foreach (var agent in agentMovements5)
            {
                agent.orangesCollected = 0;
            }
        }



        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int getAgentOrangeCount1()
        {
            int orangeCount = 0;
            foreach (var agent in agentMovements1)
            {
               orangeCount =  agent.orangesCollected;
            }


            return orangeCount;
        }



        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int getAgentOrangeCount2()
        {
            int orangeCount = 0;
            foreach (var agent in agentMovements2)
            {
                orangeCount = agent.orangesCollected;
            }


            return orangeCount;
        }


        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int getAgentOrangeCount3()
        {
            int orangeCount = 0;
            foreach (var agent in agentMovements3)
            {
                orangeCount = agent.orangesCollected;
            }


            return orangeCount;
        }


        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int getAgentOrangeCount4()
        {
            int orangeCount = 0;
            foreach (var agent in agentMovements4)
            {
                orangeCount = agent.orangesCollected;
            }


            return orangeCount;
        }


        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int getAgentOrangeCount5()
        {
            int orangeCount = 0;
            foreach (var agent in agentMovements5)
            {
                orangeCount = agent.orangesCollected;
            }


            return orangeCount;
        }


        /// <summary>
        /// This method gets the current death count
        /// </summary>
        public int getAgentDeathCount1()
        {
            int deathCount = 0;
            foreach (var agent in agentMovements1)
            {
                deathCount = agent.playerDeathCount;
            }


            return deathCount;
        }


        /// <summary>
        /// This method gets the current death count
        /// </summary>
        public int getAgentDeathCount2()
        {
            int deathCount = 0;
            foreach (var agent in agentMovements2)
            {
                deathCount = agent.playerDeathCount;
            }


            return deathCount;
        }


        /// <summary>
        /// This method gets the current death count
        /// </summary>
        public int getAgentDeathCount3()
        {
            int deathCount = 0;
            foreach (var agent in agentMovements3)
            {
                deathCount = agent.playerDeathCount;
            }


            return deathCount;
        }


        /// <summary>
        /// This method gets the current death count
        /// </summary>
        public int getAgentDeathCount4()
        {
            int deathCount = 0;
            foreach (var agent in agentMovements4)
            {
                deathCount = agent.playerDeathCount;
            }


            return deathCount;
        }


        /// <summary>
        /// This method gets the current death count
        /// </summary>
        public int getAgentDeathCount5()
        {
            int deathCount = 0;
            foreach (var agent in agentMovements5)
            {
                deathCount = agent.playerDeathCount;
            }


            return deathCount;
        }


        //The below code simplifies the above to a simple concise method

        //For player 1 start

        /// <summary>
        /// This method moves the player left
        /// </summary>
        public void player1MoveLeft() 
        {
            UpdateAgentMovementVariables1(moveLeft);
        }

        /// <summary>
        /// This method keeps the player idle
        /// </summary>
        public void player1Idle()
        {
            UpdateAgentMovementVariables1(0);
        }

        /// <summary>
        /// This method gets the player death count
        /// </summary>
        public int player1GetDeathCount()
        {
            return getAgentDeathCount1();
        }


        /// <summary>
        /// This method moves the player right
        /// </summary>
        public void player1MoveRight()
        {
            UpdateAgentMovementVariables1(moveRight);
        }

        /// <summary>
        /// This method makes the player jump
        /// </summary>
        public void player1MoveUp()
        {
            UpdateAgentMovementJump1();
        }

        /// <summary>
        /// This method sets the orange count back to 0
        /// </summary>
        public void player1SetOrangeCount()
        {
            UpdateAgentOrangeCount1();
        }

        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int player1GetOrangeCount()
        {
           return getAgentOrangeCount1();
        }

        //player 1 end

        //For player 2 start

        /// <summary>
        /// This method moves the player left
        /// </summary>
        public void player2MoveLeft()
        {
            UpdateAgentMovementVariables2(moveLeft);
        }

        /// <summary>
        /// This method keeps the player idle
        /// </summary>
        public void player2Idle()
        {
            UpdateAgentMovementVariables2(0);
        }

        /// <summary>
        /// This method gets the player death count
        /// </summary>
        public int player2GetDeathCount()
        {
            return getAgentDeathCount2();
        }

        /// <summary>
        /// This method moves the player right
        /// </summary>
        public void player2MoveRight()
        {
            UpdateAgentMovementVariables2(moveRight);
        }

        /// <summary>
        /// This method makes the player jump
        /// </summary>
        public void player2MoveUp()
        {
            UpdateAgentMovementJump2();
        }

        /// <summary>
        /// This method sets the orange count back to 0
        /// </summary>
        public void player2SetOrangeCount()
        {
            UpdateAgentOrangeCount2();
        }

        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int player2GetOrangeCount()
        {
            return getAgentOrangeCount2();
        }

        //player 2 end

        //For player 3 start

        /// <summary>
        /// This method moves the player left
        /// </summary>
        public void player3MoveLeft()
        {
            UpdateAgentMovementVariables3(moveLeft);
        }

        /// <summary>
        /// This method keeps the player idle
        /// </summary>
        public void player3Idle()
        {
            UpdateAgentMovementVariables3(0);
        }

        /// <summary>
        /// This method gets the player death count
        /// </summary>
        public int player3GetDeathCount()
        {
            return getAgentDeathCount3();
        }

        /// <summary>
        /// This method moves the player right
        /// </summary>
        public void player3MoveRight()
        {
            UpdateAgentMovementVariables3(moveRight);
        }

        /// <summary>
        /// This method makes the player jump
        /// </summary>
        public void player3MoveUp()
        {
            UpdateAgentMovementJump3();
        }

        /// <summary>
        /// This method sets the orange count back to 0
        /// </summary>
        public void player3SetOrangeCount()
        {
            UpdateAgentOrangeCount3();
        }

        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int player3GetOrangeCount()
        {
            return getAgentOrangeCount3();
        }

        //player 3 end

        //For player 4 start

        /// <summary>
        /// This method moves the player left
        /// </summary>
        public void player4MoveLeft()
        {
            UpdateAgentMovementVariables4(moveLeft);
        }

        /// <summary>
        /// This method keeps the player idle
        /// </summary>
        public void player4Idle()
        {
            UpdateAgentMovementVariables4(0);
        }

        /// <summary>
        /// This method gets the player death count
        /// </summary>
        public int player4GetDeathCount()
        {
            return getAgentDeathCount4();
        }

        /// <summary>
        /// This method moves the player right
        /// </summary>
        public void player4MoveRight()
        {
            UpdateAgentMovementVariables4(moveRight);
        }

        /// <summary>
        /// This method makes the player jump
        /// </summary>
        public void player4MoveUp()
        {
            UpdateAgentMovementJump4();
        }

        /// <summary>
        /// This method sets the orange count back to 0
        /// </summary>
        public void player4SetOrangeCount()
        {
            UpdateAgentOrangeCount4();
        }

        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int player4GetOrangeCount()
        {
           return getAgentOrangeCount4();
        }

        //player 4 end

        //For player 5 start

        /// <summary>
        /// This method moves the player left
        /// </summary>
        public void player5MoveLeft()
        {
            UpdateAgentMovementVariables5(moveLeft);
        }

        /// <summary>
        /// This method keeps the player idle
        /// </summary>
        public void player5Idle()
        {
            UpdateAgentMovementVariables5(0);
        }

        /// <summary>
        /// This method gets the player death count
        /// </summary>
        public int player5GetDeathCount()
        {
            return getAgentDeathCount5();
        }

        /// <summary>
        /// This method moves the player right
        /// </summary>
        public void player5MoveRight()
        {
            UpdateAgentMovementVariables5(moveRight);
        }

        /// <summary>
        /// This method makes the player jump
        /// </summary>
        public void player5MoveUp()
        {
            UpdateAgentMovementJump5();
        }

        /// <summary>
        /// This method sets the orange count back to 0
        /// </summary>
        public void player5SetOrangeCount()
        {
            UpdateAgentOrangeCount5();
        }

        /// <summary>
        /// This method gets the orange count
        /// </summary>
        public int player5GetOrangeCount()
        {
           return getAgentOrangeCount5();
        }

        //player 5 end
    }
}
