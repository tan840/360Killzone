using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    public Transform[] spawnPoints;
    public GameObject[] barriers;
    public float spawnTimeWait=1f;
    public bool spawnBool = true;
    public float spawnIntervals =1f;

    public int count1, count2, count3, count4 = 0;

    int spawnIndex;
    int objectIndex;

    void Start()
    {
        spawnBool = true;
        StartCoroutine(spawnRandomly () );
       // print("hi");
    }

    
    void Update()
    {
        
    }

    IEnumerator spawnRandomly()
    {

        //print("hi1");
        yield return new WaitForSeconds(spawnTimeWait);
        //print("hi2");
        while (spawnBool)
        {
            //print("hi3");
            spawnIndex = Random.Range(0, spawnPoints.Length);
            objectIndex = Random.Range(0, enemiesToSpawn.Length);
            Instantiate(enemiesToSpawn[objectIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            //print("hi4");
            yield return new WaitForSeconds(spawnIntervals);
        }
    }

}
