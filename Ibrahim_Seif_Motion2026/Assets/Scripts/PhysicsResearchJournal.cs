using UnityEngine;

public class PhysicsResearchJournal : MonoBehaviour
{
    public Rigidbody2D rb;

    public float torque;

    public bool ignoreColision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.right * 1f, ForceMode2D.Force);
        //rb.AddTorque(torque, ForceMode2D.Force);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //checks to see if the collision's gameobject
        //has a collider2D component
        if (collision.gameObject.GetComponent<Collider2D>() != null)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);


            ignoreColision = Physics2D.GetIgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            Debug.Log(ignoreColision.ToString());
        }


    }

 
}
