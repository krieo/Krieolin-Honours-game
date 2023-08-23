using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is responsible for the
/// player movements and actions such
/// as jumping and attacking
/// </summary>
public class PlayerAutoMovementScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;
    public SpriteRenderer mySpriteRenderer;
    public BoxCollider2D myCollider;
    public LayerMask myLayerMask;
    public float moveSpeed = 10;
    public float jumpHeight = 8;
    public float moveDirection = 0;
    //[SerializeField] this allows it for the elements to be present in the unity GUI if set to private

    //This will hold the values for the various player movements
    public enum PlayerMotionStates { idle, running, jumping, falling }
    public PlayerMotionStates state;
    public AudioSource audioJump;

    /// <summary>
    /// This is called before the game starts
    /// </summary>
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // float xAxis = Input.GetAxisRaw("Horizontal");
        // myRigidBody.velocity = new Vector2 (xAxis * 10, myRigidBody.velocity.y);


        //Up jump using input mapping
        //    if (Input.GetButtonDown("Jump")) 
        //   {
        //       myRigidBody.velocity = new Vector2(0,jumpHeight); 
        //   }

        //Up jump using input mapping this is modified to work with the player being ground 
        //so they cannot jump in the air
        //THIS METHOD CAN BE USED IF THE PLAYER JUMP IS TO BE LIMITED TO GROUND ONLY
        /*
        if (Input.GetButtonDown("Jump") && isPlayerOnGround() == true)
        {
            myRigidBody.velocity = new Vector2(0, jumpHeight);
            audioJump.Play();
        }
        */
        //this performs the jump action
        if (Input.GetButtonDown("Jump"))
        {
            myRigidBody.velocity = new Vector2(0, jumpHeight);
            audioJump.Play();
        }
        updatePlayerAnimation(moveDirection);
        


        //This detects if the 1 2 3 key is pressed and will load that level
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 key pressed!");
            level1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2 key pressed!");
            level2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 key pressed!");
            level3();
        }
    }


    /// <summary>
    /// This loads level 1
    /// </summary>
    public void level1()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// This loads level 2
    /// </summary>
    public void level2()
    {
        SceneManager.LoadScene(2);
    }


    /// <summary>
    /// This loads level 3
    /// </summary>
    public void level3()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// This method is used for updating the correct animation when the player moves
    /// it uses the variables/parameters created in the animator editor in Unity and sets
    /// the animation based on that
    /// </summary>
    private void updatePlayerAnimation(float movement)
    {
        //dynamic movement when button is released player still moves
        float xAxis = Input.GetAxis("Horizontal") + movement;
        myRigidBody.velocity = new Vector2(xAxis * moveSpeed, myRigidBody.velocity.y);

        PlayerMotionStates playerState = PlayerMotionStates.idle;

        //This allows for the animator to call different animations based on if the character is moving
        //moving right
        if (xAxis > 0)
        {
            playerState = PlayerMotionStates.running;
            mySpriteRenderer.flipX = false;
        }
        else if (xAxis < 0) //moving left
        {
            playerState = PlayerMotionStates.running;
            mySpriteRenderer.flipX = true;
        }
        else // idle
        {
            playerState = PlayerMotionStates.idle;
        }

        //this will check for jumping and falling
        if (myRigidBody.velocity.y > .1f)
        {
            playerState = PlayerMotionStates.jumping;
        }
        else if (myRigidBody.velocity.y < -.1f)
        {
            playerState = PlayerMotionStates.falling;
        }
        myAnimator.SetInteger("state", ((int)playerState));
    }


    /// <summary>
    /// This method checks if the player is on the ground or not
    /// </summary>
    /// <returns>true if yes, false if not</returns>
    private bool isPlayerOnGround()
    {
        return Physics2D.BoxCast(myCollider.bounds.center, myCollider.bounds.size, 0f, Vector2.down, .1f, myLayerMask);
    }


    //The code from below is aspects to determine when items in other classes are called
    /// <summary>
    /// This overrides the collision detection to detect for traps
    /// if one is detected it kills the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Debug.Log("Player died");
        }
    }

}
