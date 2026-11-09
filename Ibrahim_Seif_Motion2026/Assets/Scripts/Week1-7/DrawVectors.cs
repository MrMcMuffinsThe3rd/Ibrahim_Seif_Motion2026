using UnityEngine;

public class DrawVectors : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dVector = new Vector2(0, 1); //declares dVector as a vector2 with its x = 0 and its y = 1
        Vector2 eVector = new Vector2(3, -2); // declares eVector as a vector2 with its x = 3 and its y = -2

        Debug.DrawLine(Vector2.zero, dVector, Color.yellow, 15f); //draws dVector from origin in yellow for 15 seconds
        Debug.DrawLine(Vector2.zero, eVector, Color.grey, 15f); //draws eVector from origin in grey for 15 seconds
    }
}
