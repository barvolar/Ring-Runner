using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScripts : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position + _offset, 8f*Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
            transform.position = Vector3.zero;
    }
}
