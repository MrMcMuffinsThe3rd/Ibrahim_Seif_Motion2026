using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Vector3 startPointUp;
    public Vector3 EndPointDown;
    public Vector3 startPointLeft;
    public Vector3 endPointright;

    public Vector3 currentVelocity;
    public float speed;

    public bool patrolUpDown;
    public bool patrolLeftRight;

    public float switchTime = 0;

    private void Update()
    {
        EnemyMovement();

    }

    public void EnemyMovement()
    {
        if (patrolUpDown == true)
        {
            if (transform.position.y < EndPointDown.y)
            {
                //moves the enemy upwards
                currentVelocity += Vector3.up;
            }
            else if (transform.position.y > startPointUp.y)
            {
                //moves the enemy downwards
                currentVelocity += Vector3.down;
            }
        }
        else if (patrolLeftRight == true)
        {
            if (transform.position.x < startPointLeft.x)
            {
                //moves the enemy to the right
                currentVelocity += Vector3.right;
            }
            else if (transform.position.x > endPointright.x)
            {
                //moves the enemy to the left
                currentVelocity += Vector3.left;

            }
        }   

        switchTime += Time.deltaTime;

        if (switchTime > 5)
        {
            Debug.Log("is this running");

            switchTime = 0;
            currentVelocity = Vector3.zero;

            if (patrolLeftRight == true)
            {
                patrolUpDown = true;
                patrolLeftRight = false;
                currentVelocity.y = 1;
            }
            else if (patrolUpDown == true)
            {
                patrolLeftRight = true;
                patrolUpDown = false;
                currentVelocity.x = 1;
            }


        }

        //moves the enemy with the specified speed
        transform.position += currentVelocity.normalized * speed * Time.deltaTime;


    }

}
