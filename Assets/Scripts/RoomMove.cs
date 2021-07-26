using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChangeMin; //Initialize variables for changing player and camera position - need to set in editor
    public Vector2 cameraChangeMax;
    public Vector3 playerChange;

    private CameraMovement cam_script; //Reference the camera movement script

    public bool needText;//Create logical to determine whether or not we need the text
    public string placeName;//Create string for place name
    public GameObject text;//Get GameObject that we set up text in
    public Text placeText;

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
            cam_script.minPosition += cameraChangeMin; //Add/subtract to new camera min x/y bounds
            cam_script.maxPosition += cameraChangeMax;//Add/subtract to new camera max x/y bounds

            other.transform.position += playerChange;//Transform player position to be in new room

            if (needText) //If boolean for whether we need this text is true
            {
                StartCoroutine(placeNameCo()); //Run the coroutine to briefly display the text
            }
        }
    }

    //Make a coroutine method for holding text on screen - IEnumerator to hold for specified time during other processes
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);//Set our gameobject to be active, as it's inactive by default 
        placeText.text = placeName; //Set the text to the desired string
        yield return new WaitForSeconds(4.0f);//Wait for 3 seconds
        text.SetActive(false);//After 3 seconds, set the gameobject back to inactive
    }

}
