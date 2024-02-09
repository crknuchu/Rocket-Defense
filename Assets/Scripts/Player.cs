using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject rocketPrefab;
    public GameObject rocketStart;

    private Vector3 _rocketSpawnPoint;
    private Vector3 _target;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
        //Cursor.visible = false; // uncomment this when game is finished
    }
    
    void Update()
    {
        if (_camera != null)
            _target = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                transform.position.z));
        crosshair.transform.position = new Vector2(_target.x, _target.y);
        _rocketSpawnPoint = rocketStart.transform.position;
        
        if (Input.GetMouseButtonDown(0))
        {
            FireRocket();
        }
    }

    void FireRocket()
    {
        GameObject rocketInstance = Instantiate(rocketPrefab, _rocketSpawnPoint, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        PlayerRocketController playerRocketController = rocketInstance.GetComponent<PlayerRocketController>();
        
        if (playerRocketController != null)
        {
            playerRocketController.SetSpawnPoint(_rocketSpawnPoint);
            playerRocketController.SetTargetPoint(_target);
            playerRocketController.OnPlayerRocketDestroyed += PlayerRocketDestroyedHandler;
        }
    }

    void PlayerRocketDestroyedHandler()
    {
        Debug.Log("Rocket destroyed");
    }
}
