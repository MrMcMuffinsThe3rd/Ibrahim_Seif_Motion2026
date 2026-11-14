using UnityEngine;

public class PhysicsResearchJournal : MonoBehaviour
{
    public Rigidbody2D rb;

    public float torque;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //rb.AddForce(Vector3.right * 1f, ForceMode2D.Force);
        rb.AddTorque(torque, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTorqueForce(float torque, ForceMode2D force)
    {

    }

    public void AddTorqueImpulse(float torque, ForceMode2D force)
    {

    }
}
