using System;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float destroyDelay = 1f;

    private void Start()
    {
        InitiateBlast();
    }

    private void InitiateBlast()
    {
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyRocket enemyRocket = other.GetComponent<EnemyRocket>();
        enemyRocket.DestroyRocket();
    }
}
