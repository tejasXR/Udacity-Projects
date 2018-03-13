using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

    public Animator chestAnimator;
    public string chestAnimation;
    public GameObject chestTop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnChestOpen()
    {
        chestAnimator = chestTop.GetComponent<Animator>();
        chestAnimator.SetTrigger(chestAnimation);
    }
}
