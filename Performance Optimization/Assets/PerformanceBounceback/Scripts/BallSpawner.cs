using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public static BallSpawner current;

    public GameObject pooledBall; 
    public int ballsAmount = 20; 
    public List<GameObject> pooledBalls; 
    public static int ballPoolNum = 0; 

    private float cooldown;
    private float cooldownLength = 0.5f;

    void Awake()
    {
        current = this; 
    }

    void Start()
    {
        pooledBalls = new List<GameObject>();
        for (int i = 0; i < ballsAmount; i++)
        {
            GameObject obj = Instantiate(pooledBall);
            obj.SetActive(false);
            pooledBalls.Add(obj);
        }
    }

    public GameObject GetPooledBall()
    {
      
        if (ballPoolNum > ballsAmount - 1)
        {
            ballPoolNum = 0;
            
        }
        return pooledBalls[ballPoolNum];
    }
   	
	void Update () {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            cooldown = cooldownLength;
            SpawnBall();
        }		
	}

    void SpawnBall()
    {
        GameObject selectedBall = BallSpawner.current.GetPooledBall();
        selectedBall.transform.position = transform.position;
        Rigidbody selectedRigidbody = selectedBall.GetComponent<Rigidbody>();
        selectedRigidbody.velocity = Vector3.zero;
        selectedRigidbody.angularVelocity = Vector3.zero;
        selectedBall.SetActive(true);
        ballPoolNum++;
    }
}
