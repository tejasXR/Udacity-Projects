using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOutOfBounds : MonoBehaviour {

    public PlatformBoundaries platBound;
    public Material outOfBoundsMaterial;
    public Material normalMaterial;

    public GameMangaer gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //If the ball is too far away from the platform boundary object, change color and increase drag
		if (platBound.tooFarBool)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.sharedMaterial = outOfBoundsMaterial;
            gameManager.ballPlay = false;
            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.drag = 0.6f;
        } else
        {
            Renderer rend = GetComponent<Renderer>();
            rend.sharedMaterial = normalMaterial;
            gameManager.ballPlay = true;
        }
	}
}
