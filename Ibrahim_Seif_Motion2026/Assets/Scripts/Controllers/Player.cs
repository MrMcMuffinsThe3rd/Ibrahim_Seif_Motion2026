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
        if(Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(bombOffset);
            //SpawnBombAtOffset(new Vector(0,1));
            //SpawnBombAtOffset();
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
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

    void SpawnBombOnRandomCorner(float inDistance)
    {

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
