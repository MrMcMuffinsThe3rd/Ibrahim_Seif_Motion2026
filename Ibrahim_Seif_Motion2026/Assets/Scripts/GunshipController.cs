using UnityEngine;
using UnityEngine.InputSystem;

public class GunshipController : MonoBehaviour
{
    public Transform leftCannon;
    public Transform rightCannon;

    public GameObject cannonballPrefab;
    public float cannonballForce = 150f;

    public Rigidbody2D rb;

    void Update()
    {
        //Takes the mouse position in screen coordinates (pixels) and converts it to world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0;

        //These methods aim the cannons based on where the mouse is in the 2D space
        Vector3 leftDirection = AimCannon(mousePosition, leftCannon);
        Vector3 rightDirection = AimCannon(mousePosition, rightCannon);


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject leftSpawnedCannonBall = Instantiate(cannonballPrefab, leftCannon.position, leftCannon.rotation);
            rb = leftSpawnedCannonBall.GetComponent<Rigidbody2D>();

            rb.AddForce(leftDirection.normalized * cannonballForce, ForceMode2D.Impulse); //Anything that we need to apply force to instantly, we use .Impulse
                                                                                          //Anything like gravity or something that needs us to apply force
                                                                                          //over a time period, we use .Force
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            GameObject rightSpawnedCannonBall = Instantiate(cannonballPrefab, rightCannon.position, rightCannon.rotation);
            rb = rightSpawnedCannonBall.GetComponent<Rigidbody2D>();

            rb.AddForce(rightDirection.normalized * cannonballForce, ForceMode2D.Impulse);


        }
    }

    //Given a target position and the transform of a cannon, aims that cannon at that target
    private Vector3 AimCannon(Vector3 target, Transform cannon)
    {
        Vector3 direction = target - cannon.position;
        //If the z-valids are offset from each other, we don't want the cannons to rotate based on that
        direction.z = 0;

        //Converts the direction that we want to face into an angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        cannon.eulerAngles = new Vector3(0, 0, angle);

        //We also then finally return the direction that we want to aim based on the target
        return direction;
    }
}
