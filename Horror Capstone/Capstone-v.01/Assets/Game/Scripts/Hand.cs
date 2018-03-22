using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public GameManager gameManager;

    [Header("Controller Objects")]
    public SteamVR_TrackedObject trackedRight;
    public SteamVR_TrackedObject trackedLeft;

    private SteamVR_Controller.Device handRight;
    private SteamVR_Controller.Device handLeft;

    public bool isHandRight;
    public bool isHandLeft;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (trackedRight.gameObject.activeInHierarchy && trackedLeft.gameObject.activeInHierarchy)
        {
            // Sets device variable depending on which hand is the dominant hand
            if (gameManager.dominantLeft)
            {
                // If the dominant hand is a left hand, set the right hand normals to the left controller
                handRight = SteamVR_Controller.Input((int)trackedLeft.index);
                handLeft = SteamVR_Controller.Input((int)trackedRight.index);
            }
            else
            {
                handRight = SteamVR_Controller.Input((int)trackedRight.index);
                handLeft = SteamVR_Controller.Input((int)trackedLeft.index);
            }
        }
    }
}
