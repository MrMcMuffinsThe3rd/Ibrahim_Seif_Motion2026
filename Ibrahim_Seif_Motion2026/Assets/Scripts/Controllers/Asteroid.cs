using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector2 velocityLeft;
    Vector2 velocityRight;
    Vector2 velocityUp;
    Vector2 velocityDown;

    // Start is called before the first frame update
    void Start()
    {
        velocityLeft = new Vector2(moveSpeed, 0);
        velocityRight = new Vector2(-moveSpeed, 0);
        velocityUp = new Vector2(0, moveSpeed);
        velocityDown = new Vector2(0, -moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {

        Vector2 randomPoint = new Vector2(Random.Range(transform.position.x, maxFloatDistance), Random.Range(transform.position.y, maxFloatDistance));
        
        Vector2 moveAsteroid = transform.position;
        moveAsteroid = randomPoint * moveSpeed * Time.deltaTime;

        //moveAsteroid += randomPoint;

        Debug.Log(randomPoint);

        //if (transform.position == arrivalDistance)
        //{
        //    //choose a new random point
        //}

    }
}
