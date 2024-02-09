using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRocket : MonoBehaviour
{
    [SerializeField]
    public float points = 50;
    [SerializeField]
    private float rocketSpeed = 30f;

    private Vector2 _spawnPoint;
    private Vector2 _targetPoint;
    
    private void Start()
    {
        _spawnPoint = new Vector2(Random.Range(-10f, 10f), 6f);
        _targetPoint = new Vector2(2 * Random.Range(-4, 4), -5); // [-8,-6,...8]
        transform.position = _spawnPoint;
    }
    
    private void MoveRocket()
    {
        Vector2 rocketPosition = transform.position;
        Vector2 direction = _targetPoint - rocketPosition;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        transform.position = Vector3.MoveTowards(rocketPosition, _targetPoint, rocketSpeed * Time.deltaTime);
    }
    
    private void HandleRocketMovement()
    {
        MoveRocket();
        // SpawnTrailParticles();
        CheckIfTargetReached();
    }
    
    public void DestroyRocket()
    {
        Destroy(gameObject);
    }
    
    private void CheckIfTargetReached()
    {
        if (Vector3.Distance(transform.position, _targetPoint) <= 0)
        {
            DestroyRocket();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        handleDestroyed();
    }

    private void handleDestroyed()
    {
        DestroyRocket();
    }

    private void Update()
    {
        HandleRocketMovement();
    }
}
