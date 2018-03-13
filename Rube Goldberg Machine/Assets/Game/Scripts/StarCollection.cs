using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollection : MonoBehaviour {

    public GameMangaer gameManager;
    public GameObject ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger");
        if (other.gameObject == ball)
        {
            if (gameManager.ballPlay == true)
            {
                gameManager.Star();
                Destroy(this.gameObject);
            }
        }
    }
}
