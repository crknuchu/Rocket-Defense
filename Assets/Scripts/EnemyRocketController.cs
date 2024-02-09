using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRocket : MonoBehaviour
{
    [SerializeField]
    private float points = 50;
    [SerializeField]
    private float rocketSpeed = 30f;

    private Vector2 _spawnPoint;
    private Vector2 _targetPoint;
    
    public float GetRocketPoints()
    {
        return this.points;
    }
    
    private void Start()
    {
        _spawnPoint = new Vector2(Random.Range(-10f, 10f), 6f);
        _targetPoint = new Vector2(2 * Random.Range(-4, 4), -5); // [-8,-6,...8]
        transform.position = _spawnPoint;
    }
    
    private void Update()
    {
        HandleRocketMovement();
    }
    
    private void HandleRocketMovement()
    {
        MoveRocket();
        SpawnTrailParticles();
        CheckIfTargetReached();
    }
    
    private void MoveRocket()
    {
        Vector2 rocketPosition = transform.position;
        var direction = _targetPoint - rocketPosition;
        
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        transform.position = Vector3.MoveTowards(rocketPosition, _targetPoint, rocketSpeed * Time.deltaTime);
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
        HandleDestroyed();
    }

    private void HandleDestroyed()
    {
        DestroyRocket();
    }
    
    private void SpawnTrailParticles()
    {
        //TODO implement smoke trail
    }

    public void DestroyRocket()
    {
        Destroy(gameObject);
    }
}
