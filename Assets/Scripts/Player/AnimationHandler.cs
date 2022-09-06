using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private string _triggerDanceName = "Dance";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnableDance()
    {
        _animator.SetTrigger(_triggerDanceName);
    }
}
