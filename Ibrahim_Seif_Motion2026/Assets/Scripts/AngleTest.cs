using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{
    public List<float> Angles;
    private int currentAngleIndex = 0; //to keep track of which angle we're on
                                        //we make it private so it doesn't get messed with in the inspector

    public float circleRadius = 1;

    public Vector3 circleOffset;
    public float shiftDuration; //how much time we're waiting
    private float shiftProgress = 0f; //how much time we've waited so far

    //public float duration;

    Vector3 pointOnACircle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float fortyFiveDegree = 45f; //represented in degrees

        float ffDInRadians = fortyFiveDegree * Mathf.Deg2Rad; //converts degrees to radians

        float twoPiRadians = 2 * Mathf.PI; //represented in radians

        float tprInDegrees = twoPiRadians * Mathf.Rad2Deg; //converts radians to degrees

        //you need to use radians here
        float currentAngle = 90f;
        Mathf.Cos(currentAngle * Mathf.Deg2Rad); 
        Mathf.Sin(currentAngle * Mathf.Deg2Rad);



        pointOnACircle = new Vector3(Mathf.Cos(Angles[0]), Mathf.Sin(Angles[0])) * circleRadius;

    }

    // Update is called once per frame
    void Update()
    {
        ////////////////PROF SOLUTION - UNIT CIRCLE VALUES EXCERCISE/////////////////////////

        //when you press space, cycle to next angle in the list

        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
           
        //}

        shiftProgress += Time.deltaTime;
        if(shiftProgress > shiftDuration)
        {
            currentAngleIndex++;

            if (currentAngleIndex >= Angles.Count) //makes sure we don't go out of range, ">=" bec we start at 0 so list of 4 ends at index 3
            {
                currentAngleIndex = 0;
            }

            shiftProgress = 0f; //resets the progress
        }

        float currentAngle = Angles[currentAngleIndex];
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad; //dontt forget to convert degrees to radians before working with angles in general

        //task 1 Week 4:
        //insead of drawing from the origin to a point on a circle, get the points on the circle and draw lines between these points to draw what you want
        Vector3 startPoint = Vector3.zero + circleOffset; //circleOffset controls where the space is positioned in space
        Vector3 endPoint = new Vector3(Mathf.Cos(currentAngleInRadians), Mathf.Sin(currentAngleInRadians)) * circleRadius;

        Debug.DrawLine(startPoint, endPoint, Color.wheat);

        /////////////////////YOUR CODE////////////////////////////

        //duration += Time.deltaTime;
        
        //Debug.DrawLine(Vector3.zero, pointOnACircle); //task 2

        //for (int i = 0; i < Angles.Count; i++)
        //{
        //    if (Keyboard.current.spaceKey.wasPressedThisFrame) //task 3
        //    {
        //        pointOnACircle = new Vector3(Mathf.Cos(Angles[i]), Mathf.Sin(Angles[i])) * radius;
        //        Debug.DrawLine(Vector3.zero, pointOnACircle);
        //    }
        //}

        
    }
}
