using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Ring _ring;
    [SerializeField] private Movement _movement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out ElementRing element))
        {
            _ring.IncludeElement();
            element.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _movement.EnableDrop();
        _ring.EnableStaff();
    }
}
