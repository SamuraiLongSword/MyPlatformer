using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public bool Jump { get; private set; }
    public bool Fire { get; private set; }

    private bool IsInputAvailable { get; set; }

    private void Awake()
    {
        IsInputAvailable = true;
    }

    public void ChangeInputAccess(bool access)
    {
        IsInputAvailable = access;
        Horizontal = 0;
    }

    void Update()
    {
        if (IsInputAvailable)
        {
            Horizontal = Input.GetAxis("Horizontal");
            Jump = Input.GetButtonDown("Jump");
            Fire = Input.GetButtonDown("Fire1");
        }
    }
}
