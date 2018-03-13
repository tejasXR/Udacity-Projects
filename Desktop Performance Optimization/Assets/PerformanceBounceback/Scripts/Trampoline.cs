using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public ParticleSystem pSystem;
    public GameManager scoreScript;

	void Start () {
        scoreScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        pSystem = GetComponentInChildren<ParticleSystem>();

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            scoreScript.score++;
            pSystem.Play();
        }

    }
}
