using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
  public  Rigidbody2D playerRB;

    public float maxSpeed;

    public Transform visuals;

    public float acceleration;
    private float accelerationTime = 1;

    public float distance;

    public float apexHeight;
    public float apexTime;

     public float gravity;
     public float initialJumpVelocity;

    public bool wasJumpTriggered;

    //Vector3 currentVelocity;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerRB = GetComponent<Rigidbody2D>();

        acceleration = maxSpeed / accelerationTime;

        gravity = -2 * apexHeight / (apexTime * apexTime);

        initialJumpVelocity = 2 * apexHeight / apexTime;
    }

    void FixedUpdate()
    {
        ////The input from the player needs to be determined and then passed in to the MovementUpdate which should
        ////manage the actual movement of the character.
        Vector2 playerInput = new Vector2();

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }

        MovementUpdate(playerInput);
    }

    // Update is called once per frame
    void Update()
    {
     
        //If the player provides input for a jump, give them the initial jump velocity
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            wasJumpTriggered = true;
            //playerInput.y += apexHeight; //jump up 
        }

    }

    private void MovementUpdate(Vector2 playerInput)
    {

        Vector2 newVelocity = playerRB.linearVelocity;

        //Vector2 currentVelocity = playerRB.linearVelocity;


        //apply the gravity that we calculate over time
        newVelocity.y += gravity * Time.fixedDeltaTime; //negative means down, positive means up

        if (wasJumpTriggered == true)
        {
            newVelocity.y = initialJumpVelocity; //do i neeed a deltatime here? --> no, because you're not changing it over time,
                                                 //you're instantly setting the value
            wasJumpTriggered = false;
        }

        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
        }
        else
        {
            newVelocity = Vector2.zero;
        }
        //if (playerInput.y != 0)
        //{
        //    //jump
        //    newVelocity = playerInput * initialJumpVelocity * Time.deltaTime;
        //}
        //else
        //{
        //    newVelocity = Vector2.zero;
        //}

        playerRB.linearVelocity = newVelocity;
            


    }

    public bool IsWalking()
    {
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            //Debug.Log("character is walking");
            return true;
        }
        else 
        {
            //Debug.Log("character is still");
            return false; 
        }
        
    }
    public bool IsGrounded() //is the character on the ground?
                             //use raycasting2D -> cast a raycast from the character's feet and if it hits the ground then it's grounded 
                             //or use boxcast 
    {
        //Using: https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/physics2d/raycast


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, 1); //returns RaycastHit2D

        //Debug.Log(hit.collider.gameObject.name);

        if (hit.collider == null) 
        {
            Debug.Log("character NOT grounded");
            return false;
        }
        else
        {
            Debug.Log("character IS grounded");
            return true;
        }

    }

    public FacingDirection GetFacingDirection()
    {
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            //Debug.Log("facing left");
            return FacingDirection.left;
        }
        else
        {
            //Debug.Log("facing right");
            return FacingDirection.right;
        }
    }
}
