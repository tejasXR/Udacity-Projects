using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManager : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    //Teleportation
    private LineRenderer laser;
    public int teleportLength;
    public Vector3 teleportLocation;
    public GameObject teleportAirmer;
    public GameObject player;
    public LayerMask laserMask;

    public bool canTeleport = false;
	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            laser.gameObject.SetActive(true);
            //laser.SetPosition(0, gameObject.transform.position);
            laser.positionCount = 2;
            laser.SetPosition(0, transform.position);
            


            //If we hit something that we can teleport to
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
            {
                //Debug.Log("Raycast!");
                teleportLocation = hit.point;
                laser.SetPosition(1, teleportLocation);
                teleportAirmer.gameObject.SetActive(true);
                teleportAirmer.transform.position = teleportLocation;
                canTeleport = true;
            } else
            {
                //If we don't hit anything
                laser.SetPosition(1, transform.forward * 15 + transform.position);
                teleportAirmer.gameObject.SetActive(false);
                teleportLocation = player.transform.position;
                canTeleport = false;

            }
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (canTeleport == true)
            {
                laser.gameObject.SetActive(false);
                teleportAirmer.gameObject.SetActive(false);
                player.transform.position = teleportLocation;
            }
            else
            {
                laser.gameObject.SetActive(false);
                teleportAirmer.gameObject.SetActive(false);
                teleportLocation = player.transform.position;
            }
            
        }
    }
}
