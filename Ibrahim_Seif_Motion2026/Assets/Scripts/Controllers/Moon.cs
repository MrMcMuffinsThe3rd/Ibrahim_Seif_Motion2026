using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    public float planetVectorAngleInRadians;


    public float rotationAngle;
    public float turnAngle;
    public float rotationAngleInRadians;
    public float radius;
    public Vector3 moonPositionRelativeToPlanet;

    public Vector3 moveMoon = new Vector3(1,1);
    public float orbitalSpeed;



    public float shiftDuration;
    public float shiftProgress = 0f;

    public List<float> Angles;
    private int currentAngleIndex = 0; //to keep track of which angle we're on
                                       //we make it private so it doesn't get messed with in the inspector

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, orbitalSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        //planetVectorAngleInRadians = Mathf.Atan2(target.position.y, target.position.x);
        ////sets the position of the moon
        ////relative to the planet in unit circle

        //float planetVectorAngleInDegrees = planetVectorAngleInRadians * Mathf.Rad2Deg;

        //turnAngle += 2f;

        //planetVectorAngleInDegrees += turnAngle;

        //planetVectorAngleInRadians = planetVectorAngleInDegrees * Mathf.Deg2Rad;

        //moonPositionRelativeToPlanet = new Vector3(Mathf.Cos(planetVectorAngleInRadians), Mathf.Sin(planetVectorAngleInRadians)) * radius;



        //float numberOfPointsOnCircle = 4;

        //for(int i = 0; i < numberOfPointsOnCircle; i++)
        //{
        //   turnAngle += 360 / numberOfPointsOnCircle;
        //    float turnAngleInRadians = Mathf.Deg2Rad * turnAngle;

        //    moonPositionRelativeToPlanet = new Vector3(Mathf.Cos(planetVectorAngleInRadians), Mathf.Sin(planetVectorAngleInRadians)) * radius;
        //    transform.position += moonPositionRelativeToPlanet * speed * Time.deltaTime;
        //}

        //turnAngle += 2f;

        //planetVectorAngleInRadians += turnAngleInRadians;

        //turnAngle = 30f;

        //float turnAngleInRadians = Mathf.Deg2Rad * turnAngle;


        //Vector3 turnMoon = new Vector3(Mathf.Cos(turnAngleInRadians), Mathf.Sin(turnAngleInRadians)) * radius;

        //moveMoon = new Vector3(Mathf.Cos(turnAngleInRadians), Mathf.Sin(turnAngleInRadians)) * radius;

        //transform.position += moveMoon + transform.up * speed * Time.deltaTime;


        //transform.position = -moonPositionRelativeToPlanet;



        //shiftProgress += Time.deltaTime;
        //if (shiftProgress > shiftDuration)
        //{
        //    //currentAngleIndex++;
            

        //    if (currentAngleIndex >= Angles.Count) //makes sure we don't go out of range, ">=" bec we start at 0 so list of 4 ends at index 3
        //    {
        //        currentAngleIndex = 0;
        //    }

        //    shiftProgress = 0f; //resets the progress
        //}

        if(turnAngle > 360)
        {
            turnAngle = 0;
        }
        else
        {
            turnAngle++;
        }

        float currentAngle = turnAngle;
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad; //dontt forget to convert degrees to radians before working with angles in general

        //task 1 Week 4:
        //insead of drawing from the origin to a point on a circle, get the points on the circle and draw lines between these points to draw what you want
        Vector3 startPoint = Vector3.zero + target.position; //circleOffset controls where the space is positioned in space
        Vector3 endPoint = new Vector3(Mathf.Cos(currentAngleInRadians), Mathf.Sin(currentAngleInRadians)) * radius;

        transform.position = startPoint + endPoint;


    }
}
