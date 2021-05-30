using UnityEngine;

[RequireComponent(typeof(Animator))]

public class HealthController : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private AudioSource HitSound;

    private Animator _animator;
    private float _currentHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (GetComponent<PlayerInput>() != null) HitSound.Play();

        if (_currentHealth < 0) _currentHealth = 0;

        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public float GetHP
    {
        get { return _currentHealth; }
    }

    private void Die()
    {
        _animator.SetTrigger("Dead");

        Destroy(gameObject, 0.5f);

        if(gameObject.GetComponent<AgaricCounter>() != null)
        {
            AgaricCounter.Counter++;
        }
    }
}
