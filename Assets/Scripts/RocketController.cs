using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float rocketSpeed = 30f;

    public delegate void RocketDestroyedDelegate();
    public event RocketDestroyedDelegate OnRocketDestroyed;

    private Vector3 _targetPosition;

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
        Vector3 direction = (_targetPosition - transform.position).normalized;

        // Calculate the rotation angle to look towards the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the rocket to face towards the target
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, rocketSpeed * Time.deltaTime);

       //Vector3 velocity = direction * rocketSpeed;
       //float movementStep = rocketSpeed * Time.deltaTime;
       //Debug.Log("MovementStep: " + movementStep);
       
       // Move the rocket towards the target with constant speed
       //transform.position += velocity * Time.deltaTime;

        
        if (transform.position == _targetPosition)
        {
            //Vector3.Distance(transform.position, _targetPosition)
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
            //OnRocketDestroyed();
        }
    }
}