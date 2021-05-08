using UnityEngine;

public class SawMove : MonoBehaviour
{
    [SerializeField] private Transform Point1;
    [SerializeField] private Transform Point2;

    private Vector3 _target;
    private float _speed;

    void Start()
    {
        _target = Point1.position;
        _speed = 1;
    }

    void Update()
    {
        SawMovement();
    }

    private void SawMovement()
    {
        if (Vector3.Distance(transform.position, _target) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target, Time.deltaTime * _speed); // Movement to the current target
        }
        else
        {
            if (_target == Point1.position) // Changing the target
            {
                _target = Point2.position;
            }
            else
            {
                _target = Point1.position;
            }
        }
    }
}
