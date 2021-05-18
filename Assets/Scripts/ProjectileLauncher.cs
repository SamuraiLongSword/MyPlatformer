using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ProjectileLauncher : MonoBehaviour, ILaunch
{
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private Transform FirePoint;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Launch(float direction)
    {
        GameObject projectile = Instantiate(ProjectilePrefab, FirePoint.position, Quaternion.identity);
        Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();

        _animator.SetTrigger("DudeHit");

        if (direction > 0)
        {
            projectileRB.velocity = transform.right * 7;
        }
        else
        {
            projectileRB.velocity = transform.right * -7;
        }

    }
}
