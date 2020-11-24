using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnScript : MonoBehaviour
{
    public Transform[] spawnPosition;
    public GameObject coin;
    float timeBtwSpan = 30f;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpan <= 0)
        {
            Instantiate(coin, spawnPosition[Random.Range(0, spawnPosition.Length)].position, Quaternion.identity);
            timeBtwSpan = 30f;
        }
        else
        {
            timeBtwSpan--;
        }

    }
}