using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerationCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.gameObject.SetActive(false);

        else if(collision.gameObject.TryGetComponent(out ElementRing elementRing))
            elementRing.gameObject.SetActive(false);
    }
}
