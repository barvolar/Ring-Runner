using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float _rotationSpeed = 5f;
    private float _maxRotationAngle = 50f;
    private Vector3 _currentEulerAngles;

    private void Update()
    {
        _currentEulerAngles += new Vector3(0, 0, Input.GetAxis("Mouse X") * _rotationSpeed);
        _currentEulerAngles.z = Mathf.Clamp(_currentEulerAngles.z, -_maxRotationAngle, _maxRotationAngle);

        transform.eulerAngles = _currentEulerAngles;
    }
}
