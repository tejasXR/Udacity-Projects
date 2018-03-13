using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

    public GameObject ball;
    public float fanForce;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == ball)
        {
            Debug.Log("Fan");
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * fanForce);
        }
    }
}
