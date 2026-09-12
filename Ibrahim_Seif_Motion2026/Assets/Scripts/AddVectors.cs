using UnityEngine;
using UnityEngine.InputSystem;

public class AddVectors : MonoBehaviour
{
    public Transform rTransform;
    public Transform bTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Exercise: Week 1 Slide 28

        Vector2 rPLusB = rTransform.position + bTransform.position; //task 1 

        if (Keyboard.current.bKey.isPressed && !Keyboard.current.rKey.isPressed) //task 2
        {
            Debug.DrawLine(Vector2.zero, bTransform.position, Color.blue);
        }

        else if (Keyboard.current.rKey.isPressed && !Keyboard.current.bKey.isPressed)//task 3
        {
            Debug.DrawLine(Vector2.zero, rTransform.position, Color.red);
        }

        else if (Keyboard.current.rKey.isPressed && Keyboard.current.bKey.isPressed) //task 4
        {
            Debug.DrawLine(Vector2.zero, rPLusB, Color.magenta);
        }

        //Prof Solution

        //if (Keyboard.current.rKey.wasPressedThisFrame)
        //{
        //    Debug.DrawLine(Vector2.zero, rTransform.position, Color.red);
        //}

        //if (Keyboard.current.bKey.wasPressedThisFrame)
        //{
        //    Debug.DrawLine(Vector2.zero, bTransform.position, Color.blue);
        //}

        //Vector2 rPlusB = rTransform.position + bTransform.position;
        //bool wasRandBpressed = Keyboard.current.rKey.wasPressedThisFrame && Keyboard.current.bKey.wasPressedThisFrame;
        //if (wasRandBpressed == true)
        //{
        //    Debug.DrawLine(Vector2.zero, rPlusB, Color.magenta);
        //}
    }
}
