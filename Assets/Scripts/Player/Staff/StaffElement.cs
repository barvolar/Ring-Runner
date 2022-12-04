using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffElement : MonoBehaviour
{
    [SerializeField] private DropColliders _dropColliders;

    public void EnableDropBox()
    {
        _dropColliders.gameObject.SetActive(true);
    }
  
}
