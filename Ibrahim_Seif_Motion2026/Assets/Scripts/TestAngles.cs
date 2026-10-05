using UnityEditor;
using UnityEngine;

public class TestAngles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float firstAngle = 45f;
        //float secondAngle = 315f;

        //float firstVectorX = Mathf.Cos(45f * Mathf.Deg2Rad);
        //float secondVectorX = Mathf.Cos(315f * Mathf.Deg2Rad);

        //Debug.Log(firstVectorX);
        //Debug.Log(secondVectorX);

        //float firstAngleAgain = Mathf.Acos(firstVectorX) * Mathf.Rad2Deg;
        //float secondAngleAgain = Mathf.Acos(secondVectorX) * Mathf.Rad2Deg;

        //Debug.Log(firstAngleAgain);
        //Debug.Log(secondAngleAgain);


        //float x = 0.7f;
        //float y = 0.7f;

        //float angle = Mathf.Atan(y / x);

        //float x2 = -0.7f;
        //float y2 = -0.7f;
        //float angle2 = Mathf.Atan(y2 / x2);

        //Mathf.Atan2(0.7f, 0.7f); //does not divide these values like the examples above, it figures out where the angle is based on their positive/negative
                                            //values and where these values are on the cartesian plane
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Convert from a vector to an angle based around the x-axis (based on the x-axis means the angle starts from the x-axis rather than the y-axis)
    //(check week 5 notes)
    public static float VectorToAngle(Vector3 inVector)
    {
        float angle = Mathf.Atan2(inVector.y, inVector.x) * Mathf.Rad2Deg; 

        return angle - 90;
    }

    public static float VectorDot(Vector3 a, Vector3 b)
    {
       float dotProducts = a.x * b.x + a.y * b.y;

        return dotProducts;
    }
}
