using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<HealthController>() != null)
        {
            collision.GetComponent<HealthController>().TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}
