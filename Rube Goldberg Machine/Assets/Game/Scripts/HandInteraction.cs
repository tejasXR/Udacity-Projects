using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    //Swipe
    private float swipeSum;
    private float touchLast;
    private float touchCurrentX;
    private float touchCurrentY;

    private float distance;
    public bool hasSwipedRight;
    public bool hasSwipedLeft;
    public ObjectMenuManager menuManager;


	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        /*if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)) 
        {
            touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
        }*/

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {

            touchCurrentX = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            touchCurrentY = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;

            /*    distance = touchCurrent - touchLast;
                touchLast = touchCurrent;
                swipeSum += distance; */
        }

        //This swipe code is innaccurate and frustrating. Going to use something that is easier for the  and myself

        /*if (!hasSwipedRight)
        {
            if (swipeSum > 0.5f)
            {
                swipeSum = 0;
                SwipeRight();
                hasSwipedLeft = false;
                hasSwipedRight = true;
            }
        }

        if (!hasSwipedLeft)
        {
            if (swipeSum < -0.5f)
            {
                swipeSum = 0;
                SwipeLeft();
                hasSwipedRight = false;
                hasSwipedLeft = true;
            }
        }*/

        if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (touchCurrentY > .7f)
            {
                //Debug.Log(touchCurrentY);
                SpawnObject();
            }
            
            if (touchCurrentX > .7f)
            {
                Debug.Log(touchCurrentX);

                SwipeRight();
            }
            if (touchCurrentX < -.7f)
            {
                Debug.Log(touchCurrentX);
                SwipeLeft();
            }

        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Activate();
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Deactivate();
        }
    }
    public void Activate()
    {
        menuManager.MenuActive();
    }

    public void Deactivate()
    {
        menuManager.MenuNotActive();
    }

    public void SwipeRight()
    {
        menuManager.MenuLeft();
    }

    public void SwipeLeft()
    {
        menuManager.MenuRight();
    }

    public void SpawnObject()
    {
        menuManager.SpawnCurrentObject();
    }
    public void DestroyObject(Collider coli)
    {
        menuManager.DestroyCurrentObject(coli);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Structure")
        {
            //Debug.Log("Part Collision");
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (touchCurrentY < -.7f)
                {
                    //Destroy(other.gameObject);
                    DestroyObject(other);
                }
            }
        }
    }

}
