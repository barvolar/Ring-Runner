using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Beam : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public event UnityAction DisablinCollider;

  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DropColliders dropColliders))
        {
            DisablinCollider?.Invoke();
            this.GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log(GetComponent<CapsuleCollider>().enabled);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.TryGetComponent(out StaffElementCollider staffCollider))
            foreach (ContactPoint point in collision.contacts)
            {
                _effect.transform.position = point.point;
            }
    }

    public void DisableCollider()
    {
        GetComponent<CapsuleCollider>().enabled = false;
    }

}
