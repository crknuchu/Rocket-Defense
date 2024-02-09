using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private bool _levelOver = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyRocket rocket = other.GetComponent<EnemyRocket>();
        rocket.Explode();
        DestroyBuilding();
    }

    private void DestroyBuilding()
    {
        gameObject.SetActive(false);
        _levelOver = true;
    }
}
