using NUnit.Framework;
using UnityEditor.Tilemaps;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    public List<Transform> targetTransform;

    public int currentIndex;
    Vector3 targetVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //we need to find the angle of the vector of each of the things in the list
        //get the transform.position of the targets in the list (these will be our vectors)

        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    currentIndex++;
        //}
        //else if (currentIndex >= targetTransform.Count)
        //{
        //    currentIndex = 0;
        //}
        
        ////we are minusing our transform.position vector from our target's transform.position vector so we can get the vector from target to our looker 
        ////(like if you want vector from A to B you minus B from A)
        ////Why are we doing that instead of just getting the vector position of our target?
        ////because we want the vector between our target and our looker not the vector of our target to the origin so we can get the angle to look
        ////                                                                                                                              at the target itself
        
        //targetVector = targetTransform[currentIndex].transform.position - transform.position;

        ////next we turn it into an angle so we're able to point to it later

        //float targetAngleInRadians = TestAngles.VectorToAngle(targetVector);
        //float targetAngleInDegrees = targetAngleInRadians * Mathf.Rad2Deg;

        //    //then we make the looker point to it using its eulerAngles.z
        //    //but we need to make a vector for it first

        //    Vector3 lookerDirection = transform.eulerAngles;

        //    lookerDirection.z = targetAngleInDegrees;

        //    transform.eulerAngles = lookerDirection;



        //PROF SOLUTION
        Vector3 firsTarget = targetTransform[currentIndex].position;

        Vector3 vectorToFirstTarget = firsTarget - transform.position;

        float angleToFirstTarget = TestAngles.VectorToAngle(vectorToFirstTarget);
        //We have to set the whole vector not just the x value
        transform.eulerAngles = new Vector3(0f, 0f, angleToFirstTarget);

        //we can also use this:
        //transform.up = vectorToFirstTarget;
        //but we won't be able to rotate with a speed with this so that's why we learned to convert a vector to an angle like above

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentIndex++;

            if(currentIndex >= targetTransform.Count)
            {
                currentIndex = 0;
            }
        }

        

    }
}
