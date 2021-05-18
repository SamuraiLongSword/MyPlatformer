using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class Launcher : MonoBehaviour
{
    [SerializeField] private float FireRate;

    private PlayerInput _pInput;
    private ILaunch _launch;
    private float _timer;

    private void Awake()
    {
        _pInput = GetComponent<PlayerInput>();
        _launch = GetComponent<ILaunch>();
        _timer = 0;
    }

    private void Update()
    {
        Launch();
    }

    public void Launch()
    {
        _timer += Time.deltaTime;

        if(CanFire() && _pInput.Fire)
        {
            _launch.Launch(transform.localScale.x);
            _timer = 0;
        }
    }

    private bool CanFire()
    {
        return _timer >= FireRate;
    }
}
