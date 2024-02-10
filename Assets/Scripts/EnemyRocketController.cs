using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRocket : MonoBehaviour
{
    [SerializeField]
    private long points = 50;
    [SerializeField]
    private float rocketSpeed = 30f;
    private Player player;
    [SerializeField] private GameObject fireballPrefab;

    private Vector2 _spawnPoint;
    private Vector2 _targetPoint;
    
    public float GetRocketPoints()
    {
        return this.points;
    }
    
    private void Start()
    {
        _spawnPoint = new Vector2(Random.Range(-9f, 9f), 6f);
        _targetPoint = new Vector2(2 * Random.Range(-4, 4), -5); // [-8,-6,...8]
        transform.position = _spawnPoint;
        player = GameObject.Find("Player").GetComponent<Player>();
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
            Explode();
        }
    }

    private void CreateFireball()
    {
        GameObject fireballInstance = Instantiate(fireballPrefab, _targetPoint, Quaternion.identity);
        Fireball fireball = fireballInstance.GetComponent<Fireball>();
    }
    
    public void Explode()
    {
        
        Destroy(gameObject);
        CreateFireball();
        //create fireball
    }
    
    
    private void SpawnTrailParticles()
    {
        //TODO implement smoke trail
    }

    public void DestroyRocket()
    {
        player.IncreasePlayerScore(this.points);
        Destroy(gameObject);
    }
}
