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

    public void InitiateBlast()
    {
        Destroy(gameObject, destroyDelay);
    }
}
