using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaer : MonoBehaviour {

    public int points = 0;
    public int starsCollected;

    public bool ballPlay = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Star()
    {
        points += 3000;
        starsCollected += 1;
    }

    public void Goal()
    {
        points += 1000;
    }

    public void Reset()
    {
        points = 0;
        starsCollected = 0;
    }
}
