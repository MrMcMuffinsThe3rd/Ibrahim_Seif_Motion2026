using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform targetTransform;

    public float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);

        Vector3 directionToTarget = targetTransform.position - transform.position;

        //should we turn left or right:
        //this bool should be true if the target is on the right and should be false if the target is on the left
        bool shouldWeTurnRight = false;

        //how similiar is this direction to the right?
        //if its positive then move to the right
        //if its negative then move to the left
        float dotProductOfRight = TestAngles.VectorDot(directionToTarget, transform.right);
        shouldWeTurnRight = dotProductOfRight > 0f;

        if(shouldWeTurnRight)
        {
            transform.eulerAngles -= Vector3.forward * rotationSpeed * Time.deltaTime; //(0,0,1f)
        }
        else
        {
            transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }

        Debug.Log(shouldWeTurnRight);

    }
}
