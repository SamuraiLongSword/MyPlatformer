using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    [SerializeField] private float DamageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<HealthController>() != null)
        {
            collision.gameObject.GetComponent<HealthController>().TakeDamage(DamageAmount);
        }
    }
}
