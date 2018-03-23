using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLocomotion : MonoBehaviour {

    public GameManager gameManager;
    public SteamVR_Controller.Device device;
    public SteamVR_TrackedObject trackedObj;
    private Hand hand;


    //[Header("Controller Objects")]
    //public SteamVR_TrackedObject trackedRight;
    //public SteamVR_TrackedObject trackedLeft;

    [Header("Locomotion Vector Properties")]
    public Vector3 controllerForward;
    public Vector2 touchPad;
    public float triggerAxis;

    [Header("Player Objects")]
    public GameObject cameraRig;
    public GameObject playerEye;

    [Header("Player Sounds")]
    public AudioSource sprintingAudio;
    public AudioSource afterSprintingAudio;

    public GameObject bodyCollider;
    public GameObject footCollider;
    private Rigidbody bodyRb; //rigid body of the body Collider;

    [Header("Movement Variables")]
    #region MovementVariables
    public float moveSpeed;
    public float sprintSpeed;

    public float staminaAmnt; //current stamina amount
    public float staminaAmntMax; //maximum stamina amount

    public float sprintInertia; //the extra variable to prevent the user from immediatly speeding up while sprinting
    public float sprintInertiaSpeed; // the speed at which the player overcomes innertia
    
    public float staminaRecovery; // the amount at which the stamina is replenished
    public float staminaDrain; // the amount at which the stamina drains while sprinting

    private bool isSprinting;
    private bool sprintSoundPlayed;

    #endregion

    void Start()
    {
        staminaAmnt = staminaAmntMax;
        hand = GetComponent<Hand>();
        bodyRb = bodyCollider.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Initializes device variable every frame
        trackedObj = hand.handTrackedRight;
        device = hand.handDeviceRight;

        triggerAxis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x; //Gets depth of trigger press    


        // Enable sprinting when the touchpad is pressed and stamina != 0
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && staminaAmnt >= 0f)
        {
            staminaAmnt -= staminaDrain * Time.deltaTime;
            sprintInertia = Mathf.Lerp(sprintInertia, 1, Time.deltaTime * sprintInertiaSpeed);
            isSprinting = true;
            sprintSpeed = (staminaAmnt / staminaAmntMax);

            if (staminaAmnt >= .1f)
            {
                SprintSound();
                sprintingAudio.volume = Mathf.Lerp(sprintingAudio.volume, .07f, Time.deltaTime / 2);
            }
        }
        else
        {
            sprintSpeed = 0;
            sprintInertia = Mathf.Lerp(sprintInertia, 0, Time.deltaTime / 3f);
            sprintingAudio.volume = Mathf.Lerp(sprintingAudio.volume, 0f, Time.deltaTime);
            staminaAmnt += staminaRecovery * Time.deltaTime;
            if (staminaAmnt >= staminaAmntMax)
            {
                staminaAmnt = staminaAmntMax;
            }
            sprintSoundPlayed = false;

        }
    }

    private void FixedUpdate()
    {
        trackedObj = hand.handTrackedRight;
        device = hand.handDeviceRight;

        //Make the bodyCollider follow the player around and make it 
        //bodyCollider.transform.position = new Vector3(4, 5, 1);
        cameraRig.transform.position = new Vector3(cameraRig.transform.position.x, bodyCollider.transform.position.y, cameraRig.transform.position.z);

        if (trackedObj.gameObject.activeInHierarchy)
        {
            if (triggerAxis > .15f) //If the trigger is pressed passed a certain threshold
            {
                //Assemble beginning variables
                controllerForward = trackedObj.transform.forward;
                moveSpeed = triggerAxis + (sprintSpeed * sprintInertia);
                Vector3 direction = new Vector3(controllerForward.x, 0, controllerForward.z);
                bodyCollider.transform.position = new Vector3(playerEye.transform.position.x, bodyCollider.transform.position.y, playerEye.transform.position.z);

                //bodyRb.MovePosition(bodyCollider.transform.position + direction * Time.deltaTime);

                //cameraRig.transform.position = Vector3.Lerp(new Vector3(cameraRig.transform.position.x, footCollider.transform.position.y, cameraRig.transform.position.z), new Vector3(bodyCollider.transform.position.x, footCollider.transform.position.y, bodyCollider.transform.position.z), Time.deltaTime * moveSpeed * 5);

                cameraRig.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Force);

                //If the bodyCollider hits something within a .5 unit distance, stop, else, move the whole cameraRig
                /*RaycastHit hit;
                if (!Physics.SphereCast(new Vector3(bodyCollider.transform.position.x, bodyCollider.transform.position.y + .5f, bodyCollider.transform.position.z), .35f, direction, out hit, .35f, -1, QueryTriggerInteraction.Ignore))
                {
                    cameraRig.transform.position = Vector3.Lerp(new Vector3(cameraRig.transform.position.x, bodyCollider.transform.position.y, cameraRig.transform.position.z), cameraRig.transform.position + direction, Time.deltaTime * moveSpeed * 5);
                }*/
                //Debug.DrawRay(new Vector3(bodyCollider.transform.position.x, bodyCollider.transform.position.y + .5f, bodyCollider.transform.position.z), direction, Color.green);
            }
        }
        
    }

    private void SprintSound()
    {
        if (!sprintSoundPlayed)
        {
            sprintingAudio.Play();
            sprintSoundPlayed = true;
        }
    }
}
