using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out GroupElement groupElement))
        {
            groupElement.gameObject.SetActive(false);
        }          
    }
}
