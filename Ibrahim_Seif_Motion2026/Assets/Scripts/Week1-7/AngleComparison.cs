using UnityEngine;

public class AngleComparison : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 facingDirection = transform.up;

        //we want to convert this vector into an angle
       float facingAngle = TestAngles.VectorToAngle(facingDirection);

        //These values are difference bec unity's internal system uses the y-axis as the default axis the angles are based around
        //our VectorToAngle method uses x-asis as the default axis the angles are based around
        //to match the unity's default, we minus 90 from our returned float in VectorToAngle method

        //now that we minused 90 from our returned float, you will notice that facingAngle value in the console has an exponent number
        //that number is basically equal to 0 (0.00000someNumber) so this is fine
        Debug.Log(facingAngle);
        Debug.Log(transform.eulerAngles.z);
    }
}
