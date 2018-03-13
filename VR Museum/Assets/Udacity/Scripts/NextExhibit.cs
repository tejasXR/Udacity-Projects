using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextExhibit : MonoBehaviour {

    public GameObject nextWaypoint;
    public GameObject cameraRig;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextWaypoint()
    {
        cameraRig.transform.position = nextWaypoint.transform.position;
        cameraRig.transform.rotation = nextWaypoint.transform.rotation;
    }
}
