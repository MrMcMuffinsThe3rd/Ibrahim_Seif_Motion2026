using UnityEngine;

public class DotProductTest : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 redVector = new Vector3(Mathf.Cos(redAngle * Mathf.Deg2Rad), Mathf.Sin(redAngle * Mathf.Deg2Rad));

        Vector3 blueVector = new Vector3(Mathf.Cos(blueAngle * Mathf.Deg2Rad), Mathf.Sin(blueAngle * Mathf.Deg2Rad));

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        //if the vectors are pointing in the same direction, the dotProduct is 1
        //if they're pointing in the opposite direction, the dotProduct is -1
        //so we can use the dotProduct to see if a gameObject is facing the same direction as something (like if we want to make a turret for example)
        //(if the player is behind the turret, the dotProduct will be negative, if the player is infront of the turret, dotProduct is positive)
        Debug.Log(TestAngles.VectorDot(redVector, blueVector));
    }
}
