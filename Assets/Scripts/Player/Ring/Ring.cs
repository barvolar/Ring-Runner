using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ring : MonoBehaviour
{
    [SerializeField] private AcelerationCollider _acelerationCollider;

    private GroupElement[] _elements;
    private int _includetElementsCount;

    public event UnityAction Assembled;

    private void OnEnable()
    {
        foreach (var item in _elements)
        {
            item.Disabled += OnDisabled;
        }
    }

    private void OnDisable()
    {
        foreach (var item in _elements)
        {
            item.Disabled -= OnDisabled;
        }
    }

    private void Start()
    {
        CreateArray();
    }

    private void CreateArray()
    {
        _elements = new GroupElement[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _elements[i] = transform.GetChild(i).GetComponent<GroupElement>();
        }
    }

    private void OnDisabled()
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            if (_elements[i].gameObject.activeSelf == false)
            {
                for (int j = i; j < _elements.Length; j++)
                {
                    _elements[j].gameObject.SetActive(false);
                }
            }
        }

        CheckingCountIncludedElements();
    }

    private void CheckingCountIncludedElements()
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            if (_elements[i].gameObject.activeSelf == false)
            {
                _includetElementsCount = i;
                break;
            }

            else
                _includetElementsCount = _elements.Length;

        }

        if (_includetElementsCount == _elements.Length)
        {
            Assembled?.Invoke();
           _acelerationCollider.gameObject.SetActive(true);
        }
    }
}
