using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject rocketPrefab;
    public GameObject rocketStart;

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

        if (Input.GetMouseButtonDown(0))
        {
            FireRocket();
        }
    }

    void FireRocket()
    {
        GameObject rocketInstance = Instantiate(rocketPrefab, rocketStart.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        PlayerRocketController playerRocketController = rocketInstance.GetComponent<PlayerRocketController>();
        
        if (playerRocketController != null)
        {
            playerRocketController.SetTarget(_target);
            playerRocketController.OnPlayerRocketDestroyed += PlayerRocketDestroyedHandler;
        }
    }

    void PlayerRocketDestroyedHandler(Vector2 rocketExplosionPosition)
    {
        Debug.Log("Rocket destroyed");
        
        CreateBlastRadius(rocketExplosionPosition, 1);
    }
    
    void CreateBlastRadius(Vector3 position, float blastRadiusSize)
    {
        GameObject blastRadiusObject = new GameObject("BlastRadius");
        blastRadiusObject.transform.position = position;
        CircleCollider2D circleCollider = blastRadiusObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = blastRadiusSize;
        circleCollider.isTrigger = true;
        BlastRadius blastRadius = blastRadiusObject.AddComponent<BlastRadius>();
        blastRadius.InitiateBlast();
    }
}
