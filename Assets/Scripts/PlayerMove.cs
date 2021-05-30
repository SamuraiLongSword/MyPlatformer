using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject OverlapGameObject;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private AnimationCurve Curve;
    [SerializeField] private AudioSource JumpSound;

    private Animator _animator;
    private PlayerInput _pInput;
    private Rigidbody2D _rBody;
    private float _speed = 3;
    private float _jumpForce = 6.75f;
    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _pInput = GetComponent<PlayerInput>();
        _rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    private void FixedUpdate()
    {
        OverlapChecking();
    }

    private void OverlapChecking()
    {
        Vector3 overlapPoint = OverlapGameObject.transform.position;
        float radius = OverlapGameObject.GetComponent<CircleCollider2D>().radius;
        _isGrounded = Physics2D.OverlapCircle(overlapPoint, radius * transform.localScale.magnitude, GroundMask);

        if (_isGrounded) _animator.SetBool("DudeIsGrounded", true);
        else _animator.SetBool("DudeIsGrounded", false);
    }

    private void Movement()
    {
        float deltaX = _pInput.Horizontal * _speed;

        if(!Mathf.Approximately(deltaX, 0))
        {
            Vector2 movement = new Vector2(Curve.Evaluate(deltaX), _rBody.velocity.y);
            _rBody.velocity = movement;
            Vector3 localScale = transform.localScale;
            transform.localScale = new Vector3(Mathf.Sign(deltaX) * Mathf.Abs(localScale.x), localScale.y, localScale.z);

            _animator.SetBool("DudeRun", true);
        }
        else _animator.SetBool("DudeRun", false);
    }

    private void Jump()
    {
        if (_pInput.Jump && _isGrounded)
        {
            Vector2 jump = new Vector2(_rBody.velocity.x, _jumpForce);
            _rBody.velocity = jump;

            _animator.SetTrigger("DudeJump");

            JumpSound.Play();
        }
    }
}
