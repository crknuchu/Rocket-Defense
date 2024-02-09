using UnityEngine;

public class PlayerRocketController : MonoBehaviour
{
    public float rocketSpeed = 30f;

    public delegate void RocketDestroyedDelegate();
    public event RocketDestroyedDelegate OnRocketDestroyed;

    private Vector2 _targetPosition;

    public void SetTarget(Vector3 target)
    {
        _targetPosition = target;
    }

    void Update()
    {
        MoveRocket();
    }

    void MoveRocket()
    {
        Vector2 rocketPosition = transform.position;
        Vector2 direction = _targetPosition - rocketPosition;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        transform.position = Vector3.MoveTowards(rocketPosition, _targetPosition, rocketSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) <= 0)
        {
            //Debug.Log("Rocket position: " + transform.position);
            //Debug.Log("Target position: " + targetPosition);
            //Debug.Log("Move: " + rocketSpeed * Time.deltaTime);
            DestroyRocket();
        }
    }

    void DestroyRocket()
    {
        Destroy(gameObject);
        if (OnRocketDestroyed != null)
        {
            OnRocketDestroyed();
        }
    }
}