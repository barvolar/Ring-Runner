using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerationEffect : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Movement _movement;

    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_movement.IsAcceleration)
            _particleSystem.Play();
        else
            _particleSystem.Stop();

        Follow();
    }

    private void Follow()
    {
        transform.position = _playerPosition.position + _offset;
    }
}
