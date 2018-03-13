using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameManager gameManager;

    public int scoreOld;
    public Text text;

	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponentInChildren<Text>();
        scoreOld = gameManager.score;

    }
	
	void Update () {

        if (scoreOld != gameManager.score)
        {
            text.text = "Score: " + gameManager.score.ToString();
            scoreOld = gameManager.score;
        }
    }
}
