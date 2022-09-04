using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] private StaffElement[] _elements;

    public void Create(int count)
    {
        if (count < 0)
            count = 0;

        else if(count > _elements.Length)
            count = _elements.Length;

        for (int i = 0; i <= count; i++)
        {
            _elements[i].gameObject.SetActive(true);
            if (i == count)
                _elements[i].EnableDropBox();
        }
    }
}
