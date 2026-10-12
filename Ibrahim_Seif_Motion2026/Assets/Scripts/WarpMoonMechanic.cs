using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WarpMoonMechanic : MonoBehaviour
{
    public Transform moonTransform;
     float ratio;

    public float radius;
    public float speed;
    public float gravity;

    float turnAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //WarpMoon(moonTransform, ratio, gravity);
        OrbitMoon(radius, speed, moonTransform);
    }

    //public void WarpMoon(Transform moon, float ratio, float gravity)
    //{
    //    //getting direction to a target vector
    //    Vector2 fromEarthToMoon = moon.position - transform.position;

    //    //using this link: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html


    //    //distance from Earth and moon
    //    float distance = Vector3.Distance(transform.position, moon.position);

    //    ratio = gravity / distance * Time.deltaTime;

    //    moon.position = Vector3.Lerp(moon.position, transform.position, ratio);

    //}

    public void OrbitMoon(float radius, float speed, Transform moon)
    {
        if (turnAngle > 360)
        {
            turnAngle = 0;
        }
        else
        {
            turnAngle++;
        }

        float currentAngle = turnAngle;
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad;

        Vector3 startPoint = Vector3.zero + transform.position; //makes sure the moon orbits the earth
        Vector3 endPoint = new Vector3(Mathf.Cos(currentAngleInRadians), Mathf.Sin(currentAngleInRadians)) * radius;

        moon.position = startPoint + endPoint;
    }
}
