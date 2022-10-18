using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

[ExecuteInEditMode]
public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Camera _startCamera;
    [SerializeField] private Camera _finishCamera;
    [SerializeField] private GameObject _lookAt;
    [SerializeField] private GameObject _follow;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _aim;
    [SerializeField] private ExampleFollowSpline _exampleFollowSpline;
    [SerializeField] private Movement _movement;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;

    private Camera _currentCamera;
    private Vector3 _currentPositon;
    private Vector3 _target;
    private bool _isFollow = true;

    private void Start()
    {
        EnableStartCamera();
    }

    private void Update()
    {
        if (_isFollow)
            Follow();

        Look();
    }

    private void Follow()
    {
        OffsetHandler();

        _currentPositon = _follow.transform.position;

        _currentCamera.transform.position = new Vector3(_currentPositon.x + _position.x, _currentPositon.y + _position.y, _currentPositon.z + _position.z);
    }

    private void OffsetHandler()
    {
        if (_movement.IsAcceleration)
            _position.z = GetTargetPositionZ(-8f);
        else
            _position.z = GetTargetPositionZ(-7f);
    }

    private void Look()
    {
        _target = new Vector3(_lookAt.transform.position.x + _aim.x, _lookAt.transform.position.y + _aim.y, _lookAt.transform.position.z + _aim.z);

        _currentCamera.transform.rotation = Quaternion.LookRotation(_target - _currentCamera.transform.position);
    }

    private void EnableStartCamera()
    {
        _startCamera.gameObject.SetActive(true);
        _currentCamera = _startCamera;
        _finishCamera.gameObject.SetActive(false);
    }

    private void EnableFinishCamera()
    {
        _finishCamera.gameObject.SetActive(true);
        _currentCamera = _finishCamera;
        _startCamera.gameObject.SetActive(false);
    }

    private float GetTargetPositionZ(float targetPosition)
    {
        float speed = 2f;

        _position.z = Mathf.MoveTowards(_position.z, targetPosition, speed * Time.deltaTime);

        return _position.z;
    }

    public void DisableFollow()
    {
        EnableFinishCamera();
        _isFollow = false;
        _exampleFollowSpline.enabled = true;
    }

}
