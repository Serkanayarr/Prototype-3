using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private Vector3 spawnPosition2 = new Vector3(40, 2.5f, -3.2f);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(("SpawnObstacle"), startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); ;
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[Random.Range(0,4)], spawnPosition, obstaclePrefab[Random.Range(0,4)].transform.rotation);
            Instantiate(obstaclePrefab[4], spawnPosition2, obstaclePrefab[4].transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
