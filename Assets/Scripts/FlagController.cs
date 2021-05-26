using UnityEngine;

[RequireComponent(typeof(Animator))]

public class FlagController : MonoBehaviour
{
    [SerializeField] private GameObject[] Agarics;
    [SerializeField] private LevelCanvas Canvas;

    private Animator _animator;
    private bool _flagIsActive;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _flagIsActive = false;
    }

    private void LateUpdate()
    {
        CheckBothAgaricsAreDestroyed();
    }

    private void CheckBothAgaricsAreDestroyed()
    {
        if (Agarics != null)
        {
            if (Agarics[0] == null && Agarics[1] == null)
            {
                _animator.SetTrigger("FlagActivated");
                _flagIsActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && _flagIsActive)
        {
            _animator.SetTrigger("FlagTouched");

            Canvas.SendMessage("EndLvlPopup");
        }
    }
}
