using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    //Winning the Game
    public bool winGame = false;
    public GameObject ball;
    public GameMangaer gameManager;
    private bool win = false;
    public GameObject UI;
    public GameObject PointText;
    public string textPoints ="";
    public TextMesh text;

    //Stars
    public StarCollection starCount;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public GameObject starPrefab;

    private Vector3 star1Position;
    private Vector3 star2Position;
    private Vector3 star3Position;

    public bool sceneTimerBool;

    public float sceneTimer = 3f;
    public string sceneCurrent;
    public string nextScene;


    // Use this for initialization
    void Start () {
        UI.gameObject.SetActive(false);
        text = PointText.gameObject.GetComponent<TextMesh>();
        //text.text = "Hello";
        //text.text = "T";
        //text.text = "You Completed the \n Challenge!  \n \n" +
         //              "Points Earned: " + gameManager.points;

        star1Position = star1.transform.position;
        star2Position = star2.transform.position;
        star3Position = star3.transform.position;

        gameManager.Reset();
    }
	
	// Update is called once per frame
	void Update () {

        if (sceneTimerBool)
        {
            sceneTimer -= Time.deltaTime;
            if (sceneTimer <= 0f)
            {
                SteamVR_LoadLevel.Begin(nextScene);
            }
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ball)
        {
            if (!win && gameManager.ballPlay)
            {
                if (gameManager.starsCollected == 3)
                {
                    //Debug.Log
                    
                    gameManager.Goal();
                    text.text = "You Completed the \n Challenge!  \n \n" +
                        "Points Earned: " + gameManager.points;
                    //text.text = textPoints;

                    //gameManager.Goal();
                    UI.gameObject.SetActive(true);
                    NextLevel();
                    sceneTimerBool = true;
                    win = true;
                }
                else
                {
                    gameManager.Goal();

                    text.text = "You Got to the Goal \n" +
                        "But Didn't Collect \n" +
                        "ALL the Stars! \n" +
                        "The Game Will Retart \n" +
                        "in a few Seconds";
                    UI.gameObject.SetActive(true);
                    sceneTimerBool = true;
                    nextScene = SceneManager.GetActiveScene().name;

                }

                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;

            }
        }
    }

    public void BallDropped()
    {
        if (GameObject.Find("Star1") != null)
        {
            //
        }
        else
        {
            Instantiate(starPrefab, star1Position, Quaternion.identity);
        }

        if (GameObject.Find("Star2") != null)
        {
            //
        }
        else
        {
            Instantiate(starPrefab, star2Position, Quaternion.identity);
        }

        if (GameObject.Find("Star3") != null)
        {
            //
        }
        else
        {
            Instantiate(starPrefab, star3Position, Quaternion.identity);
        }

        gameManager.Reset();

    }

    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneCurrent = scene.name;
        switch (sceneCurrent)
        {
            case "Level One":
                nextScene = "Level Two";
                break;
            case "Level Two":
                nextScene = "Level Three";
                break;
            case "Level Three":
                nextScene = "Level Four";
                break;
            case "Level Four":
                nextScene = "Level One";
                break;
        }
    }

}
