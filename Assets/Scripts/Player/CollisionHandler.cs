using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Ring _ring;
    [SerializeField] private AnimationHandler _animationHandler;
    [SerializeField] private CameraCollisionHandler _cameraCollisionHandler;
    [SerializeField] private CameraHandler _cameraHandler;

    private Movement _movement;
    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _movement = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out ScoreBox scoreBox))
        {
            _movement.enabled = false;
            _animationHandler.EnableDance();
            _cameraHandler.DisableFollow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ElementRing element))
        {
            _ring.IncludeElement();
            element.gameObject.SetActive(false);
        }

        else if (other.TryGetComponent(out FinishPoint finishPoint))
        {
            _movement.EnableDrop();
            _ring.EnableStaff();
            _animationHandler.EnableSuperRun();
            _collider.isTrigger = false;
        }
    }
}
