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

        Vector3 start = starTransforms[0].transform.position;
        Vector3 end = starTransforms[1].transform.position;

        Vector3 start2 = starTransforms[1].transform.position;
        Vector3 end2 = starTransforms[2].transform.position;

        Vector3 start3 = starTransforms[2].transform.position;
        Vector3 end3 = starTransforms[3].transform.position;

        Vector3 start4 = starTransforms[3].transform.position;
        Vector3 end4 = starTransforms[4].transform.position;

        Vector3 start5 = starTransforms[4].transform.position;
        Vector3 end5 = starTransforms[5].transform.position;

        Vector3 start6 = starTransforms[5].transform.position;
        Vector3 end6 = starTransforms[6].transform.position;


        Debug.DrawLine(start, end, Color.green, drawingTime);
        Debug.DrawLine(start2, end2, Color.green, drawingTime);
        Debug.DrawLine(start3, end3, Color.green, drawingTime);
        Debug.DrawLine(start4, end4, Color.green, drawingTime);
        Debug.DrawLine(start5, end5, Color.green, drawingTime);
        Debug.DrawLine(start6, end6, Color.green, drawingTime);


        //Debug.DrawLine(start, end, Color.green, drawingTime * Time.deltaTime);

        //for (int i = 0; i < starTransforms.Count; i++)
        //{

        //    if (i+1 > starTransforms.Count) //if i is the last element in the list
        //    {
        //        Debug.Log("is this running?");
        //        break; //stop the loop, aka stop drawing
        //    }
        //    else
        //    {
        //        Debug.DrawLine(starTransforms[i].transform.position, starTransforms[i + 1].transform.position, Color.green, drawingTime);

        //    }

        //}
    }
}
