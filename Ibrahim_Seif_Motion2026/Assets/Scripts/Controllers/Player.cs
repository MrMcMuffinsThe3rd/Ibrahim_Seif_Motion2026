using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 bombOffset = new Vector3(0, 1);

    public float bombTrailSpacing;
    public int numberOfTrailBombs;
    //public float cornerBombDistance;
    //public float warpRatio;

    void Update()
    {
        if(Keyboard.current.bKey.wasPressedThisFrame) // task 1 part a
        {
            SpawnBombAtOffset(bombOffset);
            //SpawnBombAtOffset(new Vector(0,1));
            //SpawnBombAtOffset();
        }

        if (Keyboard.current.tKey.wasPressedThisFrame) // task 1 part b
        {
            //SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);

        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            //WarpPlayer(enemyTransform, );
        }
    }

    void SpawnBombAtOffset(Vector3 inOffset) //task 1 part a
    {
        Instantiate(bombPrefab, inOffset, Quaternion.identity);
    }

    void SpawnBombTrail(float bombSpacing, int bombsNumber) //task 1 part b
    {

        //using https://docs.unity3d.com/ScriptReference/Vector3.Distance.html

       Vector3 bombSpacingVector = transform.position - bombsTransform.position;
       bombSpacing = Mathf.Sqrt(bombSpacingVector.x * bombSpacingVector.x + bombSpacingVector.y * bombSpacingVector.y);

        //Instantiate(bombPrefab, bombSpacing, Quaternion.identity);


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
