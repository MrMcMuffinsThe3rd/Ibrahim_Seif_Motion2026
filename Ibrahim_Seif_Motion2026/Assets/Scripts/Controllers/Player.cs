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

        if (Keyboard.current.wKey.wasPressedThisFrame) //task 3
        {
            WarpPlayer(enemyTransform, warpRatio);
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
}
