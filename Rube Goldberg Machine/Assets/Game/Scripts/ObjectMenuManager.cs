using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMenuManager : MonoBehaviour {

    public List<GameObject> objectList;
    public List<GameObject> objectPrefabList;
    public List<string> objectNames;
    public List<int> objectLimits;

    public GameObject descriptionText;
    public GameObject controller;
    public int currentObject = 0;


    //Limit Objects per level
    /*public int woodPlankLimit;
    public int metalPlankLimit;
    public int smallBoxLimit;
    public int fanLimit;
    public int trampolineLimit;
    public int teleportCubeLimit;*/

    public string sceneCurrent;

    //public int currentString = 0;

    // Use this for initialization
    void Start () {
		foreach(Transform child in transform)
        {
            objectList.Add(child.gameObject);
        }

        descriptionText.GetComponent<TextMesh>().text = objectNames[currentObject];
        MenuNotActive();

        sceneCurrent = SceneManager.GetActiveScene().name;
        LevelObjectRestrict();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuActive()
    {
        objectList[currentObject].SetActive(true);
        descriptionText.GetComponent<TextMesh>().text = objectNames[currentObject] + " \n Available : " + objectLimits[currentObject];
    }

    public void MenuNotActive()
    {
        objectList[currentObject].SetActive(false);
        descriptionText.GetComponent<TextMesh>().text = "";
    }

    public void MenuLeft()
    {
        objectList[currentObject].SetActive(false);
        currentObject++;
       
        if (currentObject > objectList.Count - 1)
        {
            //Debug.Log("Test");
            currentObject = 0;
        }
        objectList[currentObject].SetActive(true);
        descriptionText.GetComponent<TextMesh>().text = objectNames[currentObject] + "x " + objectLimits[currentObject];

    }

    public void MenuRight()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
        {
            currentObject = objectList.Count - 1;
        }
        objectList[currentObject].SetActive(true);
        descriptionText.GetComponent<TextMesh>().text = objectNames[currentObject] + "x " + objectLimits[currentObject];

    }

    public void SpawnCurrentObject()
    {
        if (objectLimits[currentObject] > 0)
        {
            Ray ray = new Ray(controller.transform.position, controller.transform.forward);
            Vector3 placement = ray.GetPoint(.5f);

            var clone = Instantiate(objectPrefabList[currentObject],
                placement,
                //new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z + 3),
                objectList[currentObject].transform.rotation);
            objectLimits[currentObject]--;
            clone.name = objectNames[currentObject];
        }
      
    }
    public void DestroyCurrentObject(Collider coli)
    {
        string name = coli.gameObject.name;
        switch (name)
        {
            case "Wood Plank":
                objectLimits[0]++;
                break;
            case "Metal Plank":
                objectLimits[1]++;
                break;
            case "Small Box":
                objectLimits[2]++;
                break;
            case "Fan":
                objectLimits[3]++;
                break;
            case "Trampoline":
                objectLimits[4]++;
                break;
            case "Teleport Cube":
                objectLimits[5]++;
                break;
        }
        Destroy(coli.gameObject);
    }

    public void LevelObjectRestrict()
    {
        switch (sceneCurrent)
        {
            case "Level One":
                objectLimits[0] = 10; //Wood Plank
                objectLimits[1] = 10; //Metal Plank
                objectLimits[2] = 5; //Small Box
                objectLimits[3] = 10; //Fan
                objectLimits[4] = 2; //Trampoline
                objectLimits[5] = 2; //Teleport Cube
                break;

            case "Level Two":
                objectLimits[0] = 5; //Wood Plank
                objectLimits[1] = 2; //Metal Plank
                objectLimits[2] = 5; //Small Box
                objectLimits[3] = 3; //Fan
                objectLimits[4] = 2; //Trampoline
                objectLimits[5] = 3; //Teleport Cube
                break;

            case "Level Three":
                objectLimits[0] = 2; //Wood Plank
                objectLimits[1] = 1; //Metal Plank
                objectLimits[2] = 6; //Small Box
                objectLimits[3] = 2; //Fan
                objectLimits[4] = 1; //Trampoline
                objectLimits[5] = 1; //Teleport Cube
                break;

            case "Level Four":
                objectLimits[0] = 5; //Wood Plank
                objectLimits[1] = 1; //Metal Plank
                objectLimits[2] = 0; //Small Box
                objectLimits[3] = 1; //Fan
                objectLimits[4] = 0; //Trampoline
                objectLimits[5] = 2; //Teleport Cube
                break;
        }
    }




}
