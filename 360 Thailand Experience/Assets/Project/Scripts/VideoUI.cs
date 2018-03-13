using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoUI : MonoBehaviour {

    public GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(mainCamera.transform.position);
        
	}
}
