using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision enter");

        if (collision.gameObject.GetComponent<CannonballController>() != null) //instead of using collision.gameObject.name you could make a typo so to be safe
                                                                                // check if the collision's gameObject has the CannonballController script
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
