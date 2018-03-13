using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public GameObject coinPoof;
    Vector3 poofPosition;
    private bool clicked = false;



    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
    }
    //Create a reference to the CoinPoofPrefab
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.World);
        poofPosition = transform.position;

    }
    public void OnCoinClicked()
    {

        if (clicked == false)
        {

            MeshRenderer renderer = GetComponent<MeshRenderer>();
            renderer.enabled = false;
            //Door.Instance.locked = false;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Instantiate(coinPoof, poofPosition, Quaternion.Euler(270f, 0f, 0f));
            clicked = true;



        }
        Destroy(this.gameObject, 3f);



        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
    }



}
