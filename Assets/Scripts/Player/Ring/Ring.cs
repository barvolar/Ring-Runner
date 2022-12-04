using UnityEngine;
using UnityEngine.Events;

public class Ring : MonoBehaviour
{
    [SerializeField] private AcelerationCollider _acelerationCollider;
    [SerializeField] private GroupElement[] _elements;
    [SerializeField] private Movement _movement;
    [SerializeField] private Staff _staff;
    [SerializeField] private ParticleSystem _acelerationEffect;

    private int _includetElementsCount;

    public event UnityAction Assembled;

    private void OnEnable()
    {
        _movement.EndAcceleration += OnEndAcceleration;

        foreach (var item in _elements)
        {
            item.Disabled += OnDisabled;
        }
    }

    private void OnDisable()
    {
        _movement.EndAcceleration -= OnEndAcceleration;

        foreach (var item in _elements)
        {
            item.Disabled -= OnDisabled;
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

    private void OnEndAcceleration()
    {
        _acelerationCollider.gameObject.SetActive(false);
        _acelerationEffect.gameObject.SetActive(false);
        _elements[0].gameObject.SetActive(false);
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
            _acelerationEffect.gameObject.SetActive(true);
        }
    }

    public void IncludeElement()
    {
        foreach (var element in _elements)
        {
            if (element.gameObject.activeSelf == false)
            {
                element.gameObject.SetActive(true);
                CheckingCountIncludedElements();
                break;
            }
        }
    }

    public void EnableStaff()
    {
        _staff.gameObject.SetActive(true);
        _staff.Create(_includetElementsCount);
        gameObject.SetActive(false);
    }
}
