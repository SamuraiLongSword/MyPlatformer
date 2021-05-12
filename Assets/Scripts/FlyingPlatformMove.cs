using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatformMove : MonoBehaviour
{
    private SliderJoint2D _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<SliderJoint2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_slider.jointTranslation >= _slider.limits.max || _slider.jointTranslation <= _slider.limits.min)
        {
            var motor = _slider.motor;
            motor.motorSpeed *= -1;
            _slider.motor = motor;
        }
    }
}
