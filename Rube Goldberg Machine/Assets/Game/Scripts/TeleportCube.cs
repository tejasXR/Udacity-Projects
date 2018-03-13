using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCube : MonoBehaviour {

    public Vector3 ballVelocity;
    public Vector3 ballAngularVelocity;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionChild(Collision other)
    {
        Debug.Log("Collision");
    }

    public void Test()
    {

    }
}
