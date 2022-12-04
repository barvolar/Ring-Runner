using UnityEngine;
using UnityEngine.Events;

public class GroupElement : MonoBehaviour
{
    private GameObject[] _elements;

    public event UnityAction Disabled;

    private void Start()
    {
        _elements = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _elements[i] = transform.GetChild(i).gameObject;        
        }
    }

    private void OnDisable()
    {
        Disabled?.Invoke();
    }
}
