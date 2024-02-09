using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject rocketPrefab;
    public GameObject rocketStart;

    private Vector3 _target;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(_target.x, _target.y);

        if (Input.GetMouseButtonDown(0))
        {
            FireRocket();
        }
    }

    void FireRocket()
    {
        GameObject rocketInstance = Instantiate(rocketPrefab, rocketStart.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        RocketController rocketController = rocketInstance.GetComponent<RocketController>();
        
        if (rocketController != null)
        {
            rocketController.SetTarget(_target);
            rocketController.OnRocketDestroyed += RocketDestroyedHandler;
        }
    }

    void RocketDestroyedHandler()
    {
        Debug.Log("Rocket destroyed");
    }
}
