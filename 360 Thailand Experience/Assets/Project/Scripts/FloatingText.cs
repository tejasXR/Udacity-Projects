using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {

    public float magnitude;
    public float speed;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Mathf.Sin(Time.time) * magnitude + transform.position.y, transform.position.z), Time.deltaTime * speed);
	}
}
