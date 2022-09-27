using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator _playerAnimator;
    private string _triggerDanceName = "Dance";

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void EnableDance()
    {
        _playerAnimator.SetTrigger(_triggerDanceName);
    }
}
