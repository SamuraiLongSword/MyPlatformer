using UnityEngine;

public class DestroyBoxes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            Destroy(collision.gameObject);
        }
    }
}
