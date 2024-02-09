using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyRocket;
    [SerializeField]
    private float spawnRate;
    // [SerializeField]
    // private int enemyAmount;

    private IEnumerator spawnEnemyRocket(float spawnRate, GameObject enemyRocket)
    {
        yield return new WaitForSeconds(spawnRate);
        GameObject newEnemyRocket = Instantiate(enemyRocket);
        StartCoroutine(spawnEnemyRocket(spawnRate, enemyRocket));
    }
    
    private void Start()
    {
        StartCoroutine(spawnEnemyRocket(spawnRate, enemyRocket));
    }
}
