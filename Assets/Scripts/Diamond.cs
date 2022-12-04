using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Vector3 _offset;
    private bool _isSelected = false;
    private float _speed = 10f;

    private void Start()
    {
        _offset = new Vector3(-1.5f, 3f, 8.5f);
    }

    private void Update()
    {
        if (_isSelected)
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position + _offset, _speed * Time.deltaTime);

        if (transform.position - _offset == Camera.main.transform.position)
        {
            _isSelected = false;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        _isSelected = true;
    }
}
