using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyRocket rocket = other.GetComponent<EnemyRocket>();
        rocket.DestroyRocket();
        DestroyBuilding();
    }

    private void DestroyBuilding()
    {
        gameObject.SetActive(false);
    }
}
