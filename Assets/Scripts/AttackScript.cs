using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovementScript;

/// <summary>
/// This script is responsible for the player's bat attack
/// </summary>
public class AttackScript : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 1f;
    public float distanceToMove = 10f;
    public AudioSource audioAttack;
    public AudioSource audioAttackTarget;
    private bool isMoving = false;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Vector3 playerOffset;
    private bool isFacingRight = true;

    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer component

    /// <summary>
    /// This method is called when the game starts
    /// </summary>
    private void Start()
    {
        originalPosition = transform.position;
        playerOffset = Vector3.zero;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// This method is called every frame
    /// </summary>
    private void Update()
    {
        // Dynamic movement when the button is released, the player still moves
        float xAxis = Input.GetAxis("Horizontal");

        // Moving right
        if (xAxis > 0)
        {
            SetFacingDirection(true);
            spriteRenderer.flipX = true; // Flip the sprite along the x-axis
        }
        else if (xAxis < 0) // Moving left
        {
            SetFacingDirection(false);
            spriteRenderer.flipX = false; // Flip the sprite along the x-axis
        }

        // When the player is idle with no velocity, the projectile moves towards the right by default
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            audioAttack.Play();
            originalPosition = player.transform.position;
            playerOffset = transform.position - originalPosition;

            if (isFacingRight)
            {
                targetPosition = originalPosition + new Vector3(distanceToMove, 0f, 0f);
            }
            else
            {
                targetPosition = originalPosition - new Vector3(distanceToMove, 0f, 0f);
            }

            StartCoroutine(MoveObject());
        }
    }

    /// <summary>
    /// This method is used to move the bats attack towards the players facing direction
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveObject()
    {
        isMoving = true;

        float distance = Vector3.Distance(transform.position, targetPosition);
        float totalTime = distance / moveSpeed;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / totalTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        yield return new WaitForSeconds(1f);

        transform.position = player.transform.position + playerOffset;
        isMoving = false;
    }

    /// <summary>
    /// This overrides the ontrigger method to see
    /// if the item the bat attacked was a trap and destroys it
    /// i included raddish aswell to destroy some platform objects
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("trap") || collision.CompareTag("raddish"))
        {
            //Destroy(collision.gameObject);
            audioAttackTarget.Play();
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
        //    if (obj.transform.parent != null)
        //   {
        // string parentName = obj.transform.parent.gameObject.name;
        // if (parentName != "Traps")
        //       if(obj.transform.parent.CompareTag("trap") == true)
        //      {
        //         Destroy(obj.transform.parent.gameObject);
        //    }
        //   else
        //  {
        //     Destroy(obj);
        //}
        //  }
        //  else
        //  {
        if (obj.CompareTag("trap"))
        {
            Destroy(obj.gameObject);
        }

        //  }
    }


    // Call this method to update the player's facing direction
    public void SetFacingDirection(bool isRight)
    {
        isFacingRight = isRight;
    }
}
