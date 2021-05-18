using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public bool Jump { get; private set; }
    public bool Fire { get; private set; }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Jump = Input.GetButtonDown("Jump");
        Fire = Input.GetButtonDown("Fire1");
    }
}
