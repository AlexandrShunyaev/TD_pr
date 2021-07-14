using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private int _scrollSpeed = 1;
    [SerializeField] private float _mouseSensitivity = 1.0f;
    [SerializeField] private float _distanceFromTarget = 0.0f;

    private Camera _camera;
    private float _rotation;

    private void Awake()
    {
        _camera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButton(0))
            {
                _rotation += Input.GetAxis("Mouse X") * _mouseSensitivity;

                transform.localEulerAngles = new Vector3(45, _rotation, 0);

                transform.position = _target.position - transform.forward * _distanceFromTarget;
            }
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 20, 90);
        }

    }
}
