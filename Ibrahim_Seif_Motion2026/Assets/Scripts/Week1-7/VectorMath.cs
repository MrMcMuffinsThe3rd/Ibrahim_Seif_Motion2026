using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 upDirection = Vector3.up;

        float magnitudeOfUpDirection = upDirection.magnitude;
        Vector2 normalizedUpDirection = upDirection.normalized;

        //Distance from origin to upDirection
        float distanceToUpDirection = Vector2.Distance(upDirection, Vector2.zero);

        DrawSquare(currentMousePosition, 5f, Color.red, 0.5f);
    }


    public static Vector2 GetNormalisedVector(Vector2 vector)
    {
        float sizeOfVector = GetMagnitude(vector);

        //Gives us a vector that has a size of 1 that has the same direction as before
        Vector2 normalisedVector = new Vector2(vector.x/sizeOfVector, vector.y/sizeOfVector); //or new Vector2(vector.x, vector.y)/sizeOfVector

        return normalisedVector;
    }

    //making it public so you can access it outside of this script
    public static float GetMagnitude(Vector2 vector) //calculates the magnitude based on the pythagorean theorem
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

   public static void DrawSquare(Vector2 centerPoint, float size, Color colour, float duration) //no need to make an instance (object)   
                                                                                                //to use this method anymore
                                                                                                //e.g Vector2.Distance()
                                                                                                //e.g Debug.Log()
                                                                                                //e.g Mathf.Sqrt()
    {
        //Center point & the size

        //Color

        //Duration how long to show

        //top line
        Vector2 startPoint = centerPoint + new Vector2(-size, size);
        Vector2 endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //left line
         startPoint = centerPoint + new Vector2(-size, size);//top left
         endPoint = centerPoint + new Vector2(-size, -size);//bottom left

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //bottom line
         startPoint = centerPoint + new Vector2(-size, -size);
         endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //right line
         startPoint = centerPoint + new Vector2(size, -size);
         endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);
    }
}
