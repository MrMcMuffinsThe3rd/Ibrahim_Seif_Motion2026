using UnityEngine;
using UnityEngine.InputSystem;

public class StarsMechanic : MonoBehaviour
{
    public GameObject starsPrefab;
    public float radius;

    public float anAngle;
    public Vector3 starsOffset = Vector3.one;
    public int numberOfStars;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            SpawnStars(radius, numberOfStars);
        }
        
    }

    public void SpawnStars(float radius, int numberOfStars)
    {
        float anAngleInRadians = anAngle * Mathf.Deg2Rad;

        starsOffset = new Vector3(Mathf.Cos(anAngleInRadians), Mathf.Sin(anAngleInRadians)) * radius;

        for (int i = 0; i < numberOfStars; i++)
        {

            GameObject spawnedPowerUp = Instantiate(starsPrefab, transform.position + starsOffset, Quaternion.identity);

            anAngle += 360 / numberOfStars;

            anAngleInRadians = anAngle * Mathf.Deg2Rad;

            starsOffset = new Vector3(Mathf.Cos(anAngleInRadians), Mathf.Sin(anAngleInRadians)) * radius;
        }

    }
}
