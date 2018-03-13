using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBoundaries : MonoBehaviour {

    //public Material outofBoundsMaterial;
    public GameObject ball;
    //public GameObject player;

    private Vector3 distance;

    public bool inHands = false;
    public bool isThrown = false;
    public bool ballTouchAnything = false;

    public float tooFar;
    public bool tooFarBool;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (inHands)
        {
            distance = transform.position - ball.transform.position;
            var distanceInX = Mathf.Abs(distance.x);
            var distanceInY = Mathf.Abs(distance.y);
            var distanceInZ = Mathf.Abs(distance.z);

            if (distanceInX + distanceInZ > tooFar)
            {
                tooFarBool = true;
                Debug.Log("too far");
            }
            if (distanceInX + distanceInZ <= tooFar)
            {
                tooFarBool = false;
                //Debug.Log("too far");
            }
            ballTouchAnything = false; //resets ballTouchAnythig
        }

        if (isThrown == true && ballTouchAnything == false) //Have to have different section since this is only called when the trigger is pressed up
        {
            inHands = false;

            distance = transform.position - ball.transform.position;
            var distanceInX = Mathf.Abs(distance.x);
            var distanceInY = Mathf.Abs(distance.y);
            var distanceInZ = Mathf.Abs(distance.z);

            if (distanceInX + distanceInZ > tooFar)
            {
                tooFarBool = true;
                Debug.Log("too far");
            }            
        }
    }
}
