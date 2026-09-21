using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    void DrawConstellation()
    {
        //draw a line connecting each star to the next star in the list stars

        //Don't use a for loop, just use Vector3 start point and end point or use Vector3.lerp

        for (int i = 0; i < starTransforms.Count; i++)
        {

            if (i+1 > starTransforms.Count) //if i is the last element in the list
            {
                Debug.Log("is this running?");
                break; //stop the loop, aka stop drawing
            }
            else
            {
                Debug.DrawLine(starTransforms[i].transform.position, starTransforms[i + 1].transform.position, Color.green, drawingTime);

            }

        }
    }
}
