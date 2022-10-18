using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Movement : MonoBehaviour
{
    [SerializeField] private Rotation _rotation;
    [SerializeField] private Ring _ring;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CameraHandler _cameraHandler;
    [SerializeField] private AnimationHandler _animationHandler;

    private float _speedDrag = 300f;
    private float _speedMove = 10f;
    private float _maxSpeedMove = 20f;
    private float _currentSpeedMove;
    private float _accelerationTime = 0;
    private float _maxAccelerationTime = 2f;
    private bool _isDrop;

    private Vector3 _slidingDirection;

    public bool IsAcceleration { get; private set; }
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
        IsAcceleration = false;
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
        IsAcceleration = true;
        _animationHandler.EnableSuperRun();
    }

    private void IncreaseSpeed()
    {

        if (_currentSpeedMove > _speedMove)
        {
            _accelerationTime += Time.deltaTime;

            if (_accelerationTime >= _maxAccelerationTime)
            {
                _currentSpeedMove = _speedMove;
                EndAcceleration?.Invoke();
                _animationHandler.DisableSuperRun();
                IsAcceleration = false;
                _accelerationTime = 0;
            }
        }
    }

    public void EnableDrop()
    {
        _isDrop = true;
        _rigidbody.useGravity = true;
    }
}
