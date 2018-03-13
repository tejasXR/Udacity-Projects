using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : MonoBehaviour {
    public bool hasBeenPlayed = false;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void inPlay() {
        //If this piece has been selected
        //Make it hover above the raycast

        
    }
    public void playPiece() {
        //If the player has selected a grid area
        //Animate the piece into position
        hasBeenPlayed = true;

        //Tell our GameLogic script to occupy the game board array at the right location with a player piece
    }
}
