using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door Instance;
    public Animator doorEntranceAnimation;
    public string OpenAnimation;

    public Animator doorExitAnimation;
    public string ExitAnimation;

    public AudioClip[] doorSounds;
    public AudioSource audio;

    public bool locked = true;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 

    void Update()
    {
        GvrViewer.Instance.UpdateState();
        // If the door is opening and it is not fully raised
        // Animate the door raising up
    }

    public void OnDoorClicked()
    {


        if (this.gameObject.name == "DoorEntrance")
        {
            doorEntranceAnimation.SetTrigger(OpenAnimation);
            audio.clip = doorSounds[0];
            audio.Play();
            Destroy(this.gameObject, 3f);


            //Debug.Log("DoorEntrance");

            //doorEntranceAnimation.Play("DoorEntranceOpen");
        }

        if (this.gameObject.name == "DoorExit" && locked == false)
        {
            doorExitAnimation.SetTrigger(ExitAnimation);
            audio.clip = doorSounds[0];
            audio.Play();


        }
        else
        {
            audio.clip = doorSounds[1];
            audio.Play();

        }
        // If the door is clicked and unlocked
        // Set the "opening" boolean to true
        // (optionally) Else
        // Play a sound to indicate the door is locked
    }

    public void Unlock()
    {
        locked = false;
        // You'll need to set "locked" to false here
    }
}
