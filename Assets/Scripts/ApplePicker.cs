using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [SerializeField] private AudioSource AppleSound;

    public static int AppleCounter;

    private void Awake()
    {
        AppleCounter = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Apple")
        {
            AppleSound.Play();
            collision.GetComponent<Animator>().SetTrigger("AppleCollected");
            Destroy(collision.gameObject, 0.3f);
            AppleCounter++;
        }
    }
}
