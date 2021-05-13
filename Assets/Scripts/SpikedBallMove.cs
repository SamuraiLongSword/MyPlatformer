using UnityEngine;

public class SpikedBallMove : MonoBehaviour
{
    private HingeJoint2D _hingeJoint;
    private bool _moveLeft;
    private bool _moveRight;

    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint2D>();
        _moveLeft = true;
        _moveRight = false;
    }

    void FixedUpdate()
    {
        UpDown();
    }

    private void UpDown()
    {
        // Gameobject on its max point
        if (_hingeJoint.jointAngle > _hingeJoint.limits.max && _moveLeft)
        {
            Movement();
        }

        // Gameobject on its min point
        if (_hingeJoint.jointAngle < _hingeJoint.limits.min && _moveRight)
        {
            Movement();
        }
    }

    // Changing direction of gameobject
    private void Movement()
    {
        var motor = _hingeJoint.motor;
        motor.motorSpeed *= -1;
        _hingeJoint.motor = motor;

        _moveLeft = !_moveLeft;
        _moveRight = !_moveRight;
    }
}
