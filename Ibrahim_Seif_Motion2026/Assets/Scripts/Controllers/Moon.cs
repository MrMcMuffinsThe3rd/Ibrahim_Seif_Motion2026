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
        planetVectorAngleInRadians = Mathf.Atan2(planetTransform.transform.position.x, planetTransform.transform.position.y);
         //sets the position of the moon
        //relative to the planet in unit circle
        moonPositionRelativeToPlanet = new Vector3(Mathf.Cos(planetVectorAngleInRadians), Mathf.Sin(planetVectorAngleInRadians)) * radius;

        float numberOfPointsOnCircle = 4;

        for(int i = 0; i < numberOfPointsOnCircle; i++)
        {
           turnAngle += 360 / numberOfPointsOnCircle;
            float turnAngleInRadians = Mathf.Deg2Rad * turnAngle;

            moonPositionRelativeToPlanet = new Vector3(Mathf.Cos(planetVectorAngleInRadians), Mathf.Sin(planetVectorAngleInRadians)) * radius;
            transform.position += moonPositionRelativeToPlanet * speed * Time.deltaTime;
        }

        //turnAngle += 2f;

        //planetVectorAngleInRadians += turnAngleInRadians;

        //turnAngle += 2f;

        //float turnAngleInRadians = Mathf.Deg2Rad * turnAngle;


        //rotationAngleInRadians += turnAngleInRadians;


        //moveMoon = new Vector3(Mathf.Cos(rotationAngleInRadians), Mathf.Sin(rotationAngleInRadians)) * radius;

        //transform.position += moveMoon * speed * Time.deltaTime;

    }
}
