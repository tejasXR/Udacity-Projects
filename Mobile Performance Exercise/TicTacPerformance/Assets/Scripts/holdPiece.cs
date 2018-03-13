using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdPiece : MonoBehaviour {
    public GameObject GameLogic;
    public GameObject raycastHolder;
    public GameObject player;

    public GameObject pieceBeingHeld;
	public GameObject gravityAttractor;

    public bool holdingPiece = false;
    public float hoverHeight = 0.3f;

    RaycastHit hit;
	public float gravityFactor = 10.0f;
	private Vector3 forceDirection;

    // Use this for initialization
    void Start () {
		
	}
	public void grabPiece(GameObject selectedPiece) {
        if (selectedPiece.GetComponent<PlayerPiece>().hasBeenPlayed == false) {
            pieceBeingHeld = selectedPiece;
            holdingPiece = true;
        }
    }
	// Update is called once per frame
	void Update () {
        if (GameLogic.GetComponent<GameLogic>().playerTurn == true) {
            if (holdingPiece == true) {
                Vector3 forwardDir = raycastHolder.transform.TransformDirection(Vector3.forward) * 100;
                Debug.DrawRay(raycastHolder.transform.position, forwardDir, Color.green);


                if (Physics.Raycast(raycastHolder.transform.position, (forwardDir), out hit)) {
					gravityAttractor.transform.position = new Vector3(hit.point.x, hit.point.y + hoverHeight, hit.point.z);


					pieceBeingHeld.GetComponent<Rigidbody> ().useGravity = false;
					pieceBeingHeld.GetComponent<BoxCollider> ().enabled = false;

					pieceBeingHeld.GetComponent<Rigidbody>().AddForce(gravityAttractor.transform.position - pieceBeingHeld.transform.position);


                    if (hit.collider.gameObject.tag == "Grid Plate") {
                        if (Input.GetMouseButtonDown(0)) {
                            holdingPiece = false;
                            hit.collider.gameObject.SetActive(false);
                            pieceBeingHeld.GetComponent<PlayerPiece>().hasBeenPlayed = true;
							pieceBeingHeld.GetComponent<Rigidbody> ().useGravity = true;
							pieceBeingHeld.GetComponent<BoxCollider> ().enabled = true;
                            GameLogic.GetComponent<GameLogic>().playerMove(hit.collider.gameObject);
                        }

                    }

                }
            }
        }
    }

}








