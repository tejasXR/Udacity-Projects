using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousExhibit : MonoBehaviour {

    public GameObject previousWaypoint;
    public GameObject cameraRig;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PrevioustWaypoint()
    {
        cameraRig.transform.position = previousWaypoint.transform.position;
        cameraRig.transform.rotation = previousWaypoint.transform.rotation; 
    }
}
