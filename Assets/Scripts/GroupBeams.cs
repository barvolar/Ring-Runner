using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBeams : MonoBehaviour
{
    [SerializeField] private GameObject[] _beams;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DropColliders dropColliders))
            foreach (var beam in _beams)
            {
                beam.GetComponent<CapsuleCollider>().enabled = false;
            }
    }
}
