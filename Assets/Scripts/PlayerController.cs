using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private GameObject rocketPrefab;
    [SerializeField]
    private GameObject rocketStart;
    
    [SerializeField]
    private int numberOfAvailableRockets;
    
    //private Array availableRockets[numberOfAvailableRockets]; // TODO implement system for storing all rockets
    
    private Vector3 _rocketSpawnPoint;
    private Vector3 _target;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        //Cursor.visible = false; // uncomment this when game is finished, leave it here
    }

    private void Update()
    {
        GetCursorPosition();
        CheckForInput();
    }

    private void GetCursorPosition()
    {
        if (_camera != null)
            _target = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                transform.position.z));
        crosshair.transform.position = new Vector2(_target.x, _target.y);
    }

    private void CheckForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (numberOfAvailableRockets > 0)
            {
                FireRocket();
                numberOfAvailableRockets--;
            }
            else
            { 
                HandleNoRockets();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            // TODO special attack
            Debug.Log("Special Attack Activated");
        }
        if (Input.GetMouseButtonDown(2))
        {
            // TODO change rocket type
            Debug.Log("Rocket Type Changed");
        }
    }

    private void FireRocket()
    {
        _rocketSpawnPoint = rocketStart.transform.position;
        var rocketInstance = Instantiate(rocketPrefab, _rocketSpawnPoint, Quaternion.identity);
        var playerRocketController = rocketInstance.GetComponent<PlayerRocketController>();
        
        if (playerRocketController != null)
        {
            playerRocketController.SetSpawnPoint(_rocketSpawnPoint);
            playerRocketController.SetTargetPoint(_target);
            //playerRocketController.OnPlayerRocketDestroyed += PlayerRocketDestroyedHandler;
        }
    }

    private void HandleNoRockets()
    {
        Debug.Log("No rockets left, you dimbo!");
        throw new NotImplementedException();
        //TODO implement feedback to player when they don't have rockets left
    }

    private void PlayerRocketDestroyedHandler(Vector2 position)
    {
        Debug.Log("Rocket destroyed");
    }
}
