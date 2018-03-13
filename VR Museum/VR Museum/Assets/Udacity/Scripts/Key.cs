using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject keyPoof;
    Vector3 poofPosition;
    //public GameObject doorExit;
    public Door doorExit;
    //public AudioClip keySound;

    public AudioSource audio;

    //Create a reference to the KeyPoofPrefab and Door
    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
    }

    void Update()
    {
        poofPosition = transform.position;
        //Not required, but for fun why not try adding a Key Floating Animation here :)
        transform.Rotate(Vector3.forward * Time.deltaTime * 50, Space.World);
        //transform.localPosition = new Vector3(0f, Mathf.Sin(Time.deltaTime * Mathf.PI), 0f);

    }

    public void OnKeyClicked()
    {
        if (hasKey == false)
        {
            audio.Play();

            MeshRenderer renderer = GetComponent<MeshRenderer>();
            renderer.enabled = false;
            
            Instantiate(keyPoof, poofPosition, Quaternion.Euler(270f, 0f, 0f));
            hasKey = true;
        }
        doorExit.Unlock();
        //Door.Instance.Unlock();
        Destroy(this.gameObject, 3f);



        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy
    }


}
