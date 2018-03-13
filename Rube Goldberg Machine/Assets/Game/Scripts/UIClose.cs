using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClose : MonoBehaviour
{

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    public GameObject button;
    public GameObject UI;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        //Debug.Log("Destroy");

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Trigger");
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (other.gameObject == button)
            {
                Destroy(UI);
            }
        }
    }
}