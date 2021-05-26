using System.Collections;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] private Animator CutSceneAnimator;
    [SerializeField] private PlayerInput Player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CutSceneMethod());
        }
    }

    private IEnumerator CutSceneMethod()
    {
        Player.ChangeInputAccess(false);

        yield return new WaitForSeconds(2);
        CutSceneAnimator.SetTrigger("ChangeCam");
        yield return new WaitForSeconds(2);
        CutSceneAnimator.SetTrigger("ChangeCam");
        yield return new WaitForSeconds(2);
        CutSceneAnimator.SetTrigger("ChangeCam");
        yield return new WaitForSeconds(2);
        CutSceneAnimator.SetTrigger("ChangeCam");

        Player.ChangeInputAccess(true);
        Destroy(gameObject);
    }
}
