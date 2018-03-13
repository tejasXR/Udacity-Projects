using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandThrow : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;
    public PlatformBoundaries platBound;

    public Material[] mats; //ball material when grabbed

    //public 

    //public Material ballNormal;

    //Throw Objects
    public float throwForce;

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Throwable")
        {
            //if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                device.TriggerHapticPulse(2000);
                Renderer rend = other.GetComponent<Renderer>();
                rend.sharedMaterial = mats[1];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Throwable")
        {
            //if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                device.TriggerHapticPulse(2000);
                Renderer rend = other.GetComponent<Renderer>();
                rend.sharedMaterial = mats[0];
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Throwable")
        {
            //Debug.Log("Throwable");
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObject(other);
                
            }

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ThrowObject(other);
                
            }
        }

        if (other.gameObject.tag == "Structure")
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabPart(other);
            }

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                DetachPart(other);
            }
        }

        if (other.gameObject.tag == "TeleportCube")
        {
            if(device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("TeleGrab");
                TeleportCubeGrab(other);
            }

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                TeleportCubeDetach(other);
            }
        }
    }

    void GrabObject(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform);
        coli.GetComponent<Rigidbody>().isKinematic = true;
        platBound.inHands = true;
        Renderer rend = coli.GetComponent<Renderer>();
        rend.sharedMaterial = mats[1];


        //Debug.Log("Grab Object");
    }

    void GrabPart(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform);
        //Debug.Log("Grab Object");
    }

    void DetachPart(Collider coli)
    {
        coli.transform.SetParent(null);
        //Debug.Log("Grab Object");
    }

    void ThrowObject(Collider coli)
    {
        coli.transform.SetParent(null);
        Rigidbody rb = coli.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = device.velocity * throwForce;
        rb.angularVelocity = device.angularVelocity;
        platBound.inHands = false;
        platBound.isThrown = true; 
        //Debug.Log("Throw Object");

        Renderer rend = coli.GetComponent<Renderer>();
        rend.sharedMaterial = mats[0];

    }

    void TeleportCubeGrab(Collider coli)
    {
        coli.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        coli.transform.SetParent(gameObject.transform);
    }

    void TeleportCubeDetach(Collider coli)
    {
        coli.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        coli.transform.SetParent(null);
    }
}
