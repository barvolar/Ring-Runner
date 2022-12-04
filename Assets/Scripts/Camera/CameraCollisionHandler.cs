using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

public class CameraCollisionHandler : MonoBehaviour
{
    [SerializeField] private ExampleFollowSpline _exampleFollowSpline;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out CameraStopCollider stopCollider))
        {
            _exampleFollowSpline.enabled = false;
        }
    }
}
