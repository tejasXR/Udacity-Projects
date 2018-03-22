using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLocomotion : MonoBehaviour {

    public GameManager gameManager;

    [Header("Controller Objects")]
    public SteamVR_TrackedObject trackedRight;
    public SteamVR_TrackedObject trackedLeft;

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
    //private Rigidbody bodyRb; //rigid body of the body Collider;

    [Header("Movement Variables")]
    #region MovementVariables
    public float moveSpeed;
    public float sprintSpeed;

    public float staminaAmnt; //current stamina amount
    public float staminaAmntMax; //maximum stamina amount

    public float sprintInertia; //
    public float sprintInertiaSpeed;
    
    public float staminaRecovery;
    public float staminaDrain;

    private bool isSprinting;
    private bool sprintSoundPlayed;

    #endregion

    void Start()
    {
        staminaAmnt = staminaAmntMax;
    }

    void Update()
    {
        // Initializes device variable every frame
        SteamVR_Controller.Device device;

        // Sets device variable depending on which hand is the dominant hand
        if (gameManager.dominantLeft)
        {
            device = SteamVR_Controller.Input((int)trackedLeft.index);
            triggerAxis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x; //Gets depth of trigger press    
        }
        else
        {
            device = SteamVR_Controller.Input((int)trackedRight.index);
            triggerAxis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x; //Gets depth of trigger press    
        }


        // Enable sprinting when the touchpad is pressed
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
            sprintInertia = Mathf.Lerp(sprintInertia, 0, Time.deltaTime);
            sprintingAudio.volume = Mathf.Lerp(sprintingAudio.volume, 0f, Time.deltaTime);
            sprintSpeed = 0;
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
        //Make the bodyCollider follow the player around
        bodyCollider.transform.position = new Vector3(playerEye.transform.position.x, bodyCollider.transform.position.y, playerEye.transform.position.z); //always follow the player around
        cameraRig.transform.position = new Vector3(cameraRig.transform.position.x, bodyCollider.transform.position.y, cameraRig.transform.position.z);

        if (trackedRight.gameObject.activeInHierarchy)
        {
            if (triggerAxis > .15f) //If the trigger is pressed passed a certain threshold
            {
                //Assemble beginning variables
                controllerForward = trackedRight.transform.forward;
                moveSpeed = triggerAxis;// + (sprintSpeed * sprintInertia);
                Vector3 direction = new Vector3(controllerForward.x, 0, controllerForward.z);

                //If the bodyCollider hits something within a .5 unit distance, stop, else, move the whole cameraRig
                RaycastHit hit;
                if (!Physics.SphereCast(new Vector3(bodyCollider.transform.position.x, bodyCollider.transform.position.y + .5f, bodyCollider.transform.position.z), .35f, direction, out hit, .35f, -1, QueryTriggerInteraction.Ignore))
                {
                    cameraRig.transform.position = Vector3.Lerp(new Vector3(cameraRig.transform.position.x, bodyCollider.transform.position.y, cameraRig.transform.position.z), cameraRig.transform.position + direction, Time.deltaTime * moveSpeed * 5);
                }
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
