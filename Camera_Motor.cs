using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Camera_Motor : MonoBehaviour
{// Camera_Motor controls the movement of the camera.
 //   Follows the player character 

    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero; 

        //Check if you're out of the bounds on the X axis 
        float deltaX = lookAt.position.x - transform.position.x; //if lgr than that ur out of bounds
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            { //if focus area/center of camera is smaller than lookAt...
                delta.x = deltaX - boundX; //adjust accordingly
            }
            else //if it's larger...
            {
                delta.x = deltaX + boundX; //ditto
            }
        }

        //Check if you're inside the bounds on the Y axis 
        float deltaY = lookAt.position.y - transform.position.y; //if lgr than that ur out of bounds
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            { //if focus area/center is smaller than lookAt...
                delta.y = deltaY - boundY;
            }
            else //if it's larger...
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0); 
    }
}
