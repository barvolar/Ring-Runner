using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingElementAnimations : MonoBehaviour
{
    [SerializeField] private DeceyAnimation _deceyAnimation;
    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();  
    }

    private void OnEnable()
    {
        _animation.Play();
    }

    private void OnDisable()
    {
        Instantiate(_deceyAnimation ,transform.position,transform.rotation);
    }

}
