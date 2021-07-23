using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player_pos; //Grab the position of the player character
    public float smoothing; //Set a parameter for smoothing

    public Vector2 maxPosition;//Set parameters that for the bounds of the camera for this scene
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // This is called right before switching to a new frame, after all other calcs
    void LateUpdate()
    {

        if(transform.position != player_pos.position) //If transform of camera isn't the same as the player transform 
        {
            Vector3 targetPosition = new Vector3(player_pos.position.x,
                                                 player_pos.position.y,
                                                 transform.position.z);//Set target for camera to Lerp to, with Z position remaining fixed

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);//Clamp (bound) x coord to be at minimum the min and at max the max
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);//Clamp (bound) y coord to be at minimum the min and at max the max

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //Linearly interpolate the camera position to player position, by % smoothing

            
        }
        
    }
}
