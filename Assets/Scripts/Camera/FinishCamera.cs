using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCamera : MonoBehaviour
{
    [SerializeField] private GameObject _stopCollider;

    private void OnEnable()
    {
        _stopCollider.gameObject.SetActive(true);
    }
}
