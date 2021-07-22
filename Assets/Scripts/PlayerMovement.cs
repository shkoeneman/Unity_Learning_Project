using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 4.0f; //Declare a speed variable
    public Rigidbody2D myRigidbody; //Declare a Rigidbody2D, myRigidbody, which is a player component
    public Animator animator; //Declare our animator


    private Vector2 change; //Declare a Vector3 to be used for holding inputs

    

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>(); //Get animator component and initialize
        myRigidbody = GetComponent<Rigidbody2D>(); //Get this component and initialize it
        
    }

    // Update is called once per frame - good for inputs
    void Update()
    {
        change = Vector2.zero; //Initialize change
        change.x = Input.GetAxisRaw("Horizontal"); //Get key press - GetAxisRaw is a digital 1 or -1
        change.y = Input.GetAxisRaw("Vertical"); //Get key press - GetAxisRaw is a digital 1 or -1
        //Debug.Log(change); //Look at debugging value of change
        

    }

    //Updated more regularly - put things in here involving the physics engine
    void FixedUpdate()
    {
        UpdateAnimationAndMove();
    }


    //Function to move character and update animation
    void UpdateAnimationAndMove()
    {
        if (change != Vector2.zero) //If change is not equal to its initialization value i.e. a zero vector
        {
            MoveCharacter(); //Call our method for updating the character's position
            animator.SetFloat("moveX", change.x); //Set parameters of our blend tree to be equal to change.x and change.y
            animator.SetFloat("moveY", change.y);

            animator.SetBool("moving", true);//Set moving parameter to be true is key is being pressed/character is moving
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    //Function to update character's position
    void MoveCharacter()
    {
        //Make a method to be applied to myRigidbody
        myRigidbody.MovePosition(myRigidbody.position + change.normalized * moveSpeed * Time.fixedDeltaTime); //Add change variable (normalized to be 1) * speed of script * time passed to current position
            
    }


}
