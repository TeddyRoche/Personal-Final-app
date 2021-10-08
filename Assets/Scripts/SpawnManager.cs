using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    private float startDelay = 2;
    private float SpawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, SpawnInterval);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-95, 95), 0, Random.Range(-95, 95));
        int animalIndex = Random.Range(0, EnemyPrefab.Length);
        Instantiate(EnemyPrefab[animalIndex], spawnPos, EnemyPrefab[animalIndex].transform.rotation);
    }
}
