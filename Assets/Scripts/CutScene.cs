using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField] private Animator CutSceneAnimator;
    [SerializeField] private PlayerInput Player;
    [SerializeField] private Text TextEnemy1;
    [SerializeField] private Text TextEnemy2;
    [SerializeField] private Text TextFlag;

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

        yield return new WaitForSeconds(1);
        CutSceneAnimator.SetTrigger("ChangeCam");
        StartCoroutine(PrintText("This is the first enemy", TextEnemy1));

        yield return new WaitForSeconds(6f);

        TextEnemy1.gameObject.SetActive(false);
        CutSceneAnimator.SetTrigger("ChangeCam");
        StartCoroutine(PrintText("This is the second enemy", TextEnemy2));

        yield return new WaitForSeconds(6f);

        TextEnemy2.gameObject.SetActive(false);
        CutSceneAnimator.SetTrigger("ChangeCam");
        StartCoroutine(PrintText("Destroy both enemies and the flag becomes to activated", TextFlag));

        yield return new WaitForSeconds(10);

        TextFlag.gameObject.SetActive(false);
        CutSceneAnimator.SetTrigger("ChangeCam");

        Player.ChangeInputAccess(true);
        Destroy(gameObject);
    }

    private IEnumerator PrintText(string phraseToPrint, Text text)
    {
        yield return new WaitForSeconds(1);

        foreach (char c in phraseToPrint)
        {
            text.text += c;

            yield return new WaitForSeconds(0.15f);
        }
    }
}
