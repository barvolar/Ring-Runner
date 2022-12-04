using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBeams : MonoBehaviour
{
    [SerializeField] private Beam[] _beams;
    [SerializeField] private ParticleSystem _particle;

    private void OnEnable()
    {
        foreach (var beam in _beams)
            beam.DisablinCollider += OnDisablingCollider;
    }

    private void Start()
    {
        _particle.Play();
    }

    private void OnDisable()
    {
        foreach (var beam in _beams)
            beam.DisablinCollider -= OnDisablingCollider;
    }

    private void OnDisablingCollider()
    {
        foreach (var beam in _beams)
            beam.DisableCollider();
    }

 

}
