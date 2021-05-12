using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBallMove : MonoBehaviour
{
    private HingeJoint2D _hingeJoint;
    private bool _moveLeft;
    private bool _moveRight;

    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint2D>();
        _moveLeft = true;
        _moveRight = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpDown();
    }

    private void UpDown()
    {
        if (_hingeJoint.jointAngle > _hingeJoint.limits.max && _moveLeft)
        {
            Movement();
            _moveLeft = false;
            _moveRight = true;
        }

        if (_hingeJoint.jointAngle < _hingeJoint.limits.min && _moveRight)
        {
            Movement();
            _moveLeft = true;
            _moveRight = false;
        }
    }

    private void Movement()
    {
        var motor = _hingeJoint.motor;
        motor.motorSpeed *= -1;
        _hingeJoint.motor = motor;
    }
}
