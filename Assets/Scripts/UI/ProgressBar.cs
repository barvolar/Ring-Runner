using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _finishPoint;
    [SerializeField] private GameObject _startPoint;

    private void Update()
    {
        PositionHandler();
    }

    private void PositionHandler()
    {
        float finishPointValue = _finishPoint.transform.position.z;
        float currentPointValue = _startPoint.transform.position.z;

        SetSliderValue(finishPointValue, currentPointValue);
    }

    private void SetSliderValue(float maxValue, float currentValue)
    {
        _slider.value = currentValue / maxValue;
    }
}
