using UnityEngine;

public class FlyingPlatformMove : MonoBehaviour
{
    private SliderJoint2D _slider;

    void Start()
    {
        _slider = GetComponent<SliderJoint2D>();
    }

    void FixedUpdate()
    {
        FlyingPlatformMovement();
    }

    private void FlyingPlatformMovement()
    {
        // Changing direction of gameobject
        if (_slider.jointTranslation >= _slider.limits.max || _slider.jointTranslation <= _slider.limits.min)
        {
            var motor = _slider.motor;
            motor.motorSpeed *= -1;
            _slider.motor = motor;
        }
    }
}
