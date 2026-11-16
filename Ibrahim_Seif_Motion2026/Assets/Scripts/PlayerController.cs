using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public  Rigidbody2D playerRB;

    public float maxSpeed;

    public float acceleration;
    private float accelerationTime;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        acceleration = maxSpeed / accelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
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

    private void MovementUpdate(Vector2 playerInput)
    {

        Vector2 newVelocity = playerRB.linearVelocity;

        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput.x * Vector2.right * acceleration * Time.deltaTime;
        }
        else
        {
            //????
        }

        playerRB.linearVelocity = newVelocity;

        playerRB.linearVelocity = playerInput.x * Vector3.right * maxSpeed;


        //if (Keyboard.current.leftArrowKey.isPressed)
        //{
        //    playerRB.linearVelocity = Vector3.left * 3f;

        //}

        //if (Keyboard.current.rightArrowKey.isPressed)
        //{
        //    playerRB.linearVelocity = Vector3.right * 3f;

        //}

        //if (Keyboard.current.upArrowKey.isPressed)
        //{
        //    playerRB.linearVelocity = Vector3.up * 3f;

        //}

        //if (Keyboard.current.downArrowKey.isPressed)
        //{
        //    playerRB.linearVelocity = Vector3.down * 3f;

        //}

        //playerRB.linearVelocity = Vector3.zero;

    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true; //is the character on the ground?
        //use raycasting2D -> cast a raycast from the character's feet and if it hits the ground then it's grounded 
        //or use boxcast 
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
