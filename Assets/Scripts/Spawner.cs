using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject hexagonPrefab;

    float spawnRate = 1.0f;
    float nextTimeToSpawn = 0.0f;

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1 / spawnRate;
        }        
    }
}
