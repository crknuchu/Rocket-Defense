using System;
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
}
