using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 bombOffset = new Vector3(0, -1);

    public float bombTrailSpacing;
    public int numberOfTrailBombs;
    public float cornerBombDistance;
    public float warpRatio;
    public float asteroidDetectionDistance;

    public Vector3 currentVelocity = Vector3.right;
    public float maxSpeed;
    public float accelerationTime;
    public float deccelerationTime;
    public float currentAcceleration;
    float decceleration;

    public Vector3 currentVelocityLeftRight = Vector3.right;
    public Vector3 currentVelocityUpDown = Vector3.up;

    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        decceleration = maxSpeed / decceleration;
    }

    void Update()
    {

        //transform.position += currentVelocity * Time.deltaTime;

        //PlayerMovement();
        PlayerMovementProfSolution();


        if(Keyboard.current.bKey.wasPressedThisFrame) //task 1 part a
        {
            SpawnBombAtOffset(bombOffset);
            //SpawnBombAtOffset(new Vector(0,1));
            //SpawnBombAtOffset();
        }

        if (Keyboard.current.tKey.wasPressedThisFrame) //task 1 part b
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame) //task 2
        {
            SpawnBombOnRandomCorner(cornerBombDistance);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame) //task 3
        {
            WarpPlayer(enemyTransform, warpRatio);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame) //task 4
        {
            DetectAsteroids(asteroidDetectionDistance, asteroidTransforms);
        }
    }

    GameObject SpawnBombAtOffset(Vector3 inOffset) //i got help in tutoring here
    {
      return  Instantiate(bombPrefab, inOffset + transform.position, Quaternion.identity);
    }

    void SpawnBombTrail(float bombSpacing, int numberOfBombs) //i got help in tutoring here
    {
        for (int i = 0; i < numberOfBombs; i++)
        {
            GameObject SpawnedBomb = SpawnBombAtOffset(bombOffset);

            Vector2 whatever = SpawnedBomb.transform.position;
            whatever.y += i * bombSpacing;
            SpawnedBomb.transform.position = whatever;

            //SpawnBombAtOffset(bombOffset).transform.position += bombSpacing;

            //bombOffset.y += bombSpacing;

            //Instantiate(bombPrefab, bombSpacing + bombPrefab.transform.position.y, Quaternion.identity);

        }
    }

    void SpawnBombOnRandomCorner(float inDistance) //using normalisation? inDistance -> think of it like the magnitude of vector
                                                                        //vector3 RandomCorner -> think of it like the direction of vector
    {

            int randomCorner = Random.Range(0, 4);

            //lets try using the player position as a center point for the bombs spawning
            // so transform.position is our center point vector
            //and now we will get the vector positions of the 4 corners around the player relative to the inDistance
            //lets create a vector2 variable for transform.position first

            Vector2 playerTransform = transform.position;

        if (randomCorner == 0)
        {
            //top left corner
            Vector2 topLeftCorner = playerTransform + new Vector2(-inDistance, inDistance);
            GameObject spawnedBomb1 = Instantiate(bombPrefab, topLeftCorner, Quaternion.identity);
        }
        else if (randomCorner == 1)
        {
            //top right corner
            Vector2 topRightCorner = playerTransform + new Vector2(inDistance, inDistance);
            GameObject spawnedBomb2 = Instantiate(bombPrefab, topRightCorner, Quaternion.identity);
        }
        else if (randomCorner == 2)
        {
            //bottom left corner
            Vector2 bottomLeftCorner = playerTransform + new Vector2(-inDistance, -inDistance);
            GameObject spawnedBomb3 = Instantiate(bombPrefab, bottomLeftCorner, Quaternion.identity);
        }
        else if (randomCorner == 3)
        {
            //bottom right corner
            Vector2 bottomRightCorner = playerTransform + new Vector2(inDistance, -inDistance);
            GameObject spawnedBomb4 = Instantiate(bombPrefab, bottomRightCorner, Quaternion.identity);
        }
        
    }

    public void WarpPlayer(Transform target, float ratio)
    {
        //getting direction to a target vector
        Vector2 fromTargetToPlayer = transform.position - target.position;

        //using this link: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html


        //distance from player and target
        float distance = Vector3.Distance(transform.position, target.position);

        //ratio = distance / Mathf.Sqrt(fromTargetToPlayer.x * fromTargetToPlayer.x + fromTargetToPlayer.y * fromTargetToPlayer.y); //ratio is 1
        Debug.Log(ratio);

        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    
    }


    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        //for each in range asteroid – a line should be drawn using Debug.DrawLine
        for (int i = 0; i < inAsteroids.Count; i++)
        {
 
            //check if any of the transforms contained in “inAsteroids” are within “inMaxRange”
            //we do that by getting the magnitude of the direction to a target vector

            float DistancefromPlayerToAsteroid = Vector3.Distance(transform.position, inAsteroids[i].transform.position);

            Debug.Log(DistancefromPlayerToAsteroid);

            if (DistancefromPlayerToAsteroid < inMaxRange)
            {
                Debug.Log("Is this running?");

                //using this link: https://gamedev.stackexchange.com/questions/89776/how-can-i-draw-a-line-of-certain-length-and-direction
                //we will assign a length (2.5) to the vector
                //We have to normalise the vector between the player position and the asteroid
                //we can do that using the direction to a target method to get the vector 
                Vector3 fromPlayerToAsteroid = inAsteroids[i].transform.position - transform.position;
                fromPlayerToAsteroid.Normalize();
                Vector3 lengthVector = transform.position + (fromPlayerToAsteroid * 2.5f);

                Debug.DrawLine(transform.position, lengthVector, Color.green, 2f);
            }

        }
    }

    //Week 3 In-class excercise
    void PlayerMovement()
    {
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position -= currentVelocityLeftRight;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.position += currentVelocityLeftRight;
        }
        else if(Keyboard.current.upArrowKey.isPressed)
        {
            transform.position += currentVelocityUpDown;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.position -= currentVelocityUpDown;
        }
    }


    void PlayerMovementProfSolution()
    {
        //currentVelocity = Vector3.zero; //this is so that if the player is not pressing anything, the player won't move

        Vector3 accelerationDirection = Vector3.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationDirection += Vector3.left; //we don't need to add Time.deltatime here because technically it is not changing over time
                                                                                        //it's just moving the player
            //if the correct time has passed, make the player reach the max speed
            if (Time.deltaTime > accelerationTime)
            {
                Debug.Log("is this running");
                currentAcceleration = maxSpeed;
            }

            //Prevent the player's velocity from exceeding a maxSpeed value
            if(math.abs(currentVelocity.x) > maxSpeed)
            {
                currentAcceleration = maxSpeed;
            }
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationDirection += Vector3.right;

            //if the correct time has passed, make the player reach the max speed
            if (Time.deltaTime > accelerationTime)
            {
                accelerationDirection.x = -maxSpeed;
            }

            //Prevent the player's velocity from exceeding a maxSpeed value
            if (math.abs(currentVelocity.x) > maxSpeed)
            {
                accelerationDirection = Vector3.zero;
            }
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationDirection += Vector3.up;

            if (Time.deltaTime > accelerationTime)
            {
                accelerationDirection.y = maxSpeed;
            }

            if (math.abs(currentVelocity.y) > maxSpeed)
            {
                accelerationDirection = Vector3.zero;
            }
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationDirection += Vector3.down;

            if (Time.deltaTime > accelerationTime)
            {
                accelerationDirection.y = -maxSpeed;
            }

            if (math.abs(currentVelocity.y) > maxSpeed)
            {
                accelerationDirection = Vector3.zero;
            }
        }


        //ACCELERATION DIRECTION REPRESENTS THE DIRECTION WE ARE ACCELERATING
        //WE NORMALIZE IT 
        //AND THEN SET THE AMOUNT TO ACCELERATE BY:
        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime; //we added Time.deltatime because there's change over time
                                                                           //we're normalising here so if the player is pressing two buttoms at once, 
                                                                                                            //they don't get an increased speed

        //this is the solution for the previous apparently (not done, complete it in week 3 journal)
        if(currentVelocity.magnitude > maxSpeed)
        {
            //normalise and multiply it by maxSpeed so that it is moving at maxSpeed (i have a 7 and i want to turn it to 3 so i divide the 7 by itself (normalisation) and then multiply by 3)
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }

        transform.position += currentVelocity * Time.deltaTime; //we dont need to normalise here because normalising will shrink down the velocity and give us the same
                                                                //speed which we don't want

      
    }


}
