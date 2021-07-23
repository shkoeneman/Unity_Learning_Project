using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChangeMin; //Initialize variables for changing player and camera position
    public Vector2 cameraChangeMax;
    public Vector3 playerChange;
    private CameraMovement cam_script; //Reference the camera movement script



    // Start is called before the first frame update
    void Start()
    {
        cam_script = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Check whether collider tag is the Player
        {
            cam_script.minPosition += cameraChangeMin;
            cam_script.maxPosition += cameraChangeMax;

            other.transform.position += playerChange;
        }
    }

}
