using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignText : MonoBehaviour
{

    public GameObject dialogBox;//Get reference to GameObject that needs dialogue - this is our speech bubble
    public Text dialogText;//Get reference to dialog box from Canvas
    public string dialog;//Set string that we want
    public bool playerInRange;//Declare a boolean for whether this dialog box is active


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange) //Check if space key is pressed (only first one for GetKeyDown) AND player is in collider range
        {
            if (dialogBox.activeInHierarchy) //Check whether the dialogBox is active
            {
                dialogBox.SetActive(false);//If it's active, player is in range, and space pressed again, make it inactive
            }
            else
            {
                dialogBox.SetActive(true);//If it's inactive, player is in range, and space pressed, make it active
                dialogText.text = dialog;//Set dialog box text to use our text string
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other) //Use unity built-in method for when collider is triggered
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player in range");//Debug log to test player being in range
            playerInRange = true;//Set bool to true
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Use unity built-in method for when trigger goes OFF
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player left range");//Debug log to test player leaving range
            playerInRange = false;//Set bool to false
            dialogBox.SetActive(false);//Set dialog box to inactive if player leaves
        }
    }
}
