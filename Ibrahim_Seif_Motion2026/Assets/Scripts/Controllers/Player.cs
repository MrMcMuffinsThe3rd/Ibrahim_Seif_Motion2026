using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    void Update()
    {
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

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //WarpPlayer(enemyTransform, );
        }
    }

    GameObject SpawnBombAtOffset(Vector3 inOffset)
    {
      return  Instantiate(bombPrefab, inOffset + transform.position, Quaternion.identity);
    }

    void SpawnBombTrail(float bombSpacing, int numberOfBombs)
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

        

       //direction to a target 
       //if the value of the ratio is 1
       if(ratio == 1f)
        {
            //move player
            transform.position = Vector2.up; //it'll move all the way
        }
       //if value of the ratio is 0.5 it'll move halfway
       else if (ratio == 0.5f)
        {
            transform.position = Vector2.up / 2; //moves halfway
        }
       //if the value of the ratio is 0, it won't move
       else if(ratio == 0f) 
        {
            transform.position = transform.position; //will not move
        }
       else if(ratio > 1f)
        {
            transform.position = transform.position; //will not move
        }
    }
}
