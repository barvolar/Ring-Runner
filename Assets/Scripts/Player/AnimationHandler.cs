using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationHandler : MonoBehaviour
{
    private RigBuilder _rigBuilder;
    private Animator _playerAnimator;
    private string _triggerDanceName = "Dance";
    private string _boolAccelerationName = "IsAcceleration";

    private void Start()
    {
        _rigBuilder = GetComponent<RigBuilder>();
        _playerAnimator = GetComponent<Animator>();
    }

    public void EnableDance()
    {
        _playerAnimator.SetTrigger(_triggerDanceName);
        _rigBuilder.Clear();
    }

    public void EnableSuperRun()
    {
        _playerAnimator.SetBool(_boolAccelerationName, true);
    }

    public void DisableSuperRun()
    {
        _playerAnimator.SetBool(_boolAccelerationName, false);
    }
}
