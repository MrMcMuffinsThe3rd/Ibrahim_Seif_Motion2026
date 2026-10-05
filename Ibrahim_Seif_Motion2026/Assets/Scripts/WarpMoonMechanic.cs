using UnityEngine;

public class WarpMoonMechanic : MonoBehaviour
{
    public Transform earthTransform;
     float ratio;
    public float gravity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WarpMoon(earthTransform, ratio, gravity);
    }

    public void WarpMoon(Transform target, float ratio, float gravity)
    {
        //getting direction to a target vector
        Vector2 fromEarthToMoon = transform.position - target.position;

        //using this link: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html


        //distance from Earth and moon
        float distance = Vector3.Distance(transform.position, target.position);

        ratio = gravity / distance * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, target.position, ratio);

    }
}
