using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

    public Material normalMaterial;
    public PlatformBoundaries platBound;
    public Vector3 ballReset;
    public Rigidbody rb;
    public Renderer rend;
    public Goal goal;

    public 

    // Use this for initialization
    void Start () {
        ballReset = transform.position;
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();


    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision");
        if (collision.gameObject.tag == "Ground")
        {
            platBound.tooFarBool = false;
            platBound.isThrown = false;
            platBound.inHands = false;
            rend.sharedMaterial = normalMaterial;
            Debug.Log("material chnage to normal");
            rb.velocity = Vector3.zero;
            transform.position = ballReset;
            

            goal.BallDropped();


        }
    }
}
