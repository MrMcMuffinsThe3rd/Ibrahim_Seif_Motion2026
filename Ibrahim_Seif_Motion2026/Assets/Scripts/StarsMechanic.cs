using UnityEngine;
using UnityEngine.InputSystem;

public class StarsMechanic : MonoBehaviour
{
    public GameObject starsPrefab;
    public float radius;

    public float anAngle;
    public Vector3 starsOffset = Vector3.one;
    public int numberOfStars;


    float ratio;
    public float gravity;
    //public Transform starTransform;


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

        WarpStars(starsPrefab.transform, ratio, gravity);

    }

    public void SpawnStars(float radius, int numberOfStars)
    {
        float anAngleInRadians = anAngle * Mathf.Deg2Rad;

        starsOffset = new Vector3(Mathf.Cos(anAngleInRadians), Mathf.Sin(anAngleInRadians)) * radius;

        for (int i = 0; i < numberOfStars; i++)
        {

            GameObject spawnedStar = Instantiate(starsPrefab, transform.position + starsOffset, Quaternion.identity);

            anAngle += 360 / numberOfStars;

            anAngleInRadians = anAngle * Mathf.Deg2Rad;

            starsOffset = new Vector3(Mathf.Cos(anAngleInRadians), Mathf.Sin(anAngleInRadians)) * radius;

        }

        
    }

    public void WarpStars(Transform star, float ratio, float gravity)
    {
        //getting direction to a target vector
        Vector2 fromEarthToStar = star.position - transform.position;

        //using this link: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html


        //distance from Earth and star
        float distance = Vector3.Distance(transform.position, star.position);

        ratio = gravity / distance * Time.deltaTime;

        star.position = Vector3.Lerp(star.position, transform.position, ratio);
    }
}
