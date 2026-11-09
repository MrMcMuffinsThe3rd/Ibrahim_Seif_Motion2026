using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{

    //declaring vectors
   public Vector2 aVector = new Vector2(0, 2);
   public Vector2 bVector = new Vector2(2, 2);
   public Vector2 cVector = new Vector2(2, 0);
    public Vector2 dVector = new Vector2(0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //we want to take the mouse.x and mouse.y positions and input them in a vector
        Vector2 mousePos = Camera.current.ScreenToWorldPoint(Mouse.current.position.ReadValue()); //got this from my semester 2 week 3 notes
        Vector2 aVector = mousePos;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //draw a white square at the position you clicked on the screen -> using directional target
            //aVector (0,2)
            //bVector (2,2)
            //cVector (2,0)
            //dVector (0,0) origin

            //Debug.DrawLine(aVector, bVector, Color.white, 15f);
            //Debug.DrawLine(cVector, dVector, Color.white, 15f);
            //Debug.DrawLine(cVector, bVector, Color.white, 15f);
            Debug.DrawLine(aVector, dVector, Color.white, 15f);



        }
    }
}
