using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private float WaterDamageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthController>() != null)
        {
            collision.GetComponent<HealthController>().TakeDamage(WaterDamageAmount);
        }
    }
}
