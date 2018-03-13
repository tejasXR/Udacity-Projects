using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BangkokTemple()
    {
        SceneManager.LoadScene("Bangkok Temple", LoadSceneMode.Single);
    }

    public void PhuketTemple()
    {
        SceneManager.LoadScene("Phuket Temple", LoadSceneMode.Single);
    }

    public void Opening()
    {
        SceneManager.LoadScene("Opening", LoadSceneMode.Single);
    }

    public void Ending()
    {
        SceneManager.LoadScene("Ending", LoadSceneMode.Single);
    }
}
