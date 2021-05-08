using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private float _speed;
    private float _timer;
    private Vector3 _startPosition;

    void Start()
    {
        _speed = 0.5f;
        _timer = 0;
        _startPosition = transform.position;
    }

    void Update()
    {
        BackgroundMovement();
    }

    private void BackgroundMovement()
    {
        _timer += Time.deltaTime;

        var shift = Mathf.Repeat(_timer * _speed, 10.2f); // Value in the range  0...10.2

        transform.position = _startPosition + Vector3.down * shift; // Looping background move
    }
}
