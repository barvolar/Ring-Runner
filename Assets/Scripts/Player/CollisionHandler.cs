using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Ring _ring;
    [SerializeField] private Movement _movement;
    [SerializeField] private AnimationHandler _animationHandler;
    [SerializeField] private CameraCollisionHandler _cameraCollisionHandler;
    [SerializeField] private CameraHandler _cameraHandler;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out ElementRing element))
        {
            _ring.IncludeElement();
            element.gameObject.SetActive(false);
        }

        else if(collision.gameObject.TryGetComponent(out ScoreBox scoreBox))
        {
            _movement.enabled = false;
            _animationHandler.EnableDance();
            _cameraHandler.DisableFollow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _movement.EnableDrop();
        _ring.EnableStaff();
    }
}
