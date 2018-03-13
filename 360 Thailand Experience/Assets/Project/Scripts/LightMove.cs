using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour {

    private Light light;

    public Vector3 endPosition;
    public Quaternion endRotation;
    public float endIntensity;

    public float moveSpeed;
    public float rotateSpeed;
    public float intensitySpeed;

    public bool isTriggered;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTriggered)
        {
            var desiredRotation = Quaternion.Euler(endRotation.x, endRotation.y, endRotation.z);

            transform.position = Vector3.Slerp(transform.position, endPosition, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotateSpeed);

            light.intensity = Mathf.Lerp(light.intensity, endIntensity, Time.deltaTime * intensitySpeed);
        }
	}
}
