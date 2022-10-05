using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    [SerializeField] private Sprite pressedButtonSprite; // active button sprite
    [SerializeField] private GameObject door; //door you want to link to the button

    //safety checks
    private bool interactable = false; 
    private bool doorOpened = false;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        

        //sets the button bool to true to allow it to be pressed
        if (doorOpened == false)
        {
            // this will run the base funtion so that the interact prompt pops up and dissapears
            base.OnTriggerEnter2D(collision);
            interactable = true; // if the door hasn't already been openened lets the player interact with the button
        }
    }

    private void Update()
    {
        // checks to see if the player presses E while in front of the button
        if (Input.GetKeyDown(KeyCode.E) && interactable == true)
        {
            interactable = false; // makes it so you cant press button again
            doorOpened = true; // makes it so you can't leave the collider and come back in and press it again

            this.gameObject.GetComponent<SpriteRenderer>().sprite = pressedButtonSprite; // changes the button to green
            door.GetComponent<Door>().OpenDoor(); // gets the door script and runs the open door fuction from it
        }
    }
}
