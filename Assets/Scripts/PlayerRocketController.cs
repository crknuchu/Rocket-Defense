using System;
using UnityEngine;

public class PlayerRocketController : MonoBehaviour
{
    public GameObject fireballPrefab;
    
    public float points = 50;
    private Vector2 _spawnPoint;
    private Vector2 _targetPoint;
    [SerializeField]
    private float _rocketSpeed = 30f;
    [SerializeField]
    private float _blastRadiusSize = 1f;
    
    public delegate void PlayerRocketDestroyedDelegate();
    public event PlayerRocketDestroyedDelegate OnPlayerRocketDestroyed;
    
    public void SetSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }
    
    public void SetTargetPoint(Vector3 target)
    {
        _targetPoint = target;
    }

    void Update()
    {
        MoveRocket();
    }

    void MoveRocket()
    {
        Vector2 rocketPosition = transform.position;
        Vector2 direction = _targetPoint - rocketPosition;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        transform.position = Vector3.MoveTowards(rocketPosition, _targetPoint, _rocketSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPoint) <= 0)
        {
            CreateFireball();
            DestroyRocket();
        }
    }

    private void CreateFireball()
    {
        GameObject fireballInstance = Instantiate(fireballPrefab, _targetPoint, Quaternion.identity);
        Fireball fireball = fireballInstance.GetComponent<Fireball>();
        CircleCollider2D circleCollider = fireball.GetComponent<CircleCollider2D>();
        circleCollider.radius = _blastRadiusSize;
    }

    void DestroyRocket()
    {
        if (OnPlayerRocketDestroyed != null)
        {
            OnPlayerRocketDestroyed();
        }
        
        Destroy(gameObject);
    }
}