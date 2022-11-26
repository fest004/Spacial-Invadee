using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField]
    [Range(0f, 1f)]
    float lagAmount = 0;


    Vector3 previousCameraPosition;
    Transform _camera;
    Vector3 targetPosition;
    
    private float parallaxAmount => 1f - lagAmount;
    
    // Start is called before the first frame update
    
    private void Awake()
    {
        _camera = Camera.main.transform;
        previousCameraPosition = _camera.position;
    }
    
    void Update()
    {
       Vector3 _movement = CameraMovement; 
       if (_movement == Vector3.zero) return;
       targetPosition = new Vector3(transform.position.x + _movement.x * parallaxAmount, transform.position.y + _movement.y * parallaxAmount, transform.position.z);
        transform.position = targetPosition;
    }
    
    Vector3 CameraMovement
    {
        get
        {
            Vector3 _movement = _camera.position - previousCameraPosition;
            previousCameraPosition = _camera.position; 
            return _movement;
        }
    }
}
