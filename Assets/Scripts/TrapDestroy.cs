using UnityEngine;

public class TrapDestroy : MonoBehaviour
{
    // Destroys any of gameobjects getting in here
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject, 0.2f);
    }
}
