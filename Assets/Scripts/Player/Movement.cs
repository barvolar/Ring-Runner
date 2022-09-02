using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Movement : MonoBehaviour
{
   [SerializeField] protected Rotation _rotation;
   [SerializeField] private Ring _ring;
   [SerializeField] private Rigidbody _rigidbody;
   
    private float _speedDrag = 300f;
    private float _speedMove = 20f;
    private float _maxSpeedMove = 40f;
    private float _currentSpeedMove;
    private float _accelerationTime = 0;
    private float _maxAccelerationTime = 2f;
    private bool _isDrop;

    private Vector3 _slidingDirection;

    public event UnityAction EndAcceleration;

    private void OnEnable()
    {
        _ring.Assembled += OnAssembled;
    }

    private void OnDisable()
    {        
        _ring.Assembled -= OnAssembled;
    }

    private void Start()
    {
     
        _isDrop = false;

        _currentSpeedMove = _speedMove;
    }

    private void Update()
    {
        MoveForward();

        if (_isDrop)
        {
            MoveLeftRight();
            DisableRotation();
        }

        IncreaseSpeed();
    }

    private void MoveForward()
    {

        transform.Translate(Vector3.forward * _currentSpeedMove * Time.deltaTime);

    }

    private void MoveLeftRight()
    {
        _slidingDirection += new Vector3(Input.GetAxis("Mouse X") * _speedDrag * Time.deltaTime, 0, 0);
        _slidingDirection.x = Mathf.Clamp(_slidingDirection.x, -0.3f, 0.3f); //?????? ?????
        transform.Translate(_slidingDirection * _speedMove * Time.deltaTime);
    }

    private void DisableRotation()
    {
        _rotation.enabled = false;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnAssembled()
    {
        _currentSpeedMove = _maxSpeedMove;
    }

    private void IncreaseSpeed()
    {

        if (_currentSpeedMove > _speedMove)
        {
            _accelerationTime += Time.deltaTime;

            if (_accelerationTime >= _maxAccelerationTime)
            {
                _currentSpeedMove = _speedMove;
            }
        }

    }

    public void EnableDrop()
    {
        _isDrop = true;
        _rigidbody.useGravity = true;
    }
}
