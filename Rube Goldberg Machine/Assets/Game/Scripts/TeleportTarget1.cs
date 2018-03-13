using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTarget1 : MonoBehaviour {

    public GameObject ball;
    public TeleportCube teleportManager;
    public GameObject teleportEject;
    public float extraForce;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
        Debug.Log(ball);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {

            Debug.Log("Teleportation Cube + Ball");
            Rigidbody rb = ball.gameObject.GetComponent<Rigidbody>();
            teleportManager.ballVelocity = rb.velocity;
            teleportManager.ballAngularVelocity = rb.angularVelocity;
            ball.transform.position = teleportEject.transform.position + teleportEject.transform.forward;

            rb.velocity = teleportEject.transform.forward * extraForce;
            //rb.velocity = teleportManager.ballVelocity;
            //rb.angularVelocity = teleportManager.ballAngularVelocity;

        }
    }
}
