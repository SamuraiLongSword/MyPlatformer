using System.Collections;
using UnityEngine;

public class BoxEffector : MonoBehaviour
{
    [SerializeField] private GameObject BoxWithEffectorPrefab;
    [SerializeField] private GameObject EffectorPoint;
    [SerializeField] private Animator Box2Animator;

    private void Awake()
    {
        if(EffectorPoint != null) EffectorPoint.SetActive(false); // Turns off this gameobject on awake to disable its explosive effect
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SawCentral")
        {
            StartCoroutine(ExplosiveEffect());
        }
    }

    private IEnumerator ExplosiveEffect()
    {
        if(EffectorPoint != null) EffectorPoint.SetActive(true);  // Turns on gameobject with explosive effect

        Box2Animator.SetTrigger("BoxBreaking");                   // Activates animator's trigger to turn on animation of destroying the box

        yield return new WaitForSeconds(0.1f);

        if(BoxWithEffectorPrefab != null) Destroy(BoxWithEffectorPrefab);
        Destroy(gameObject, 0.5f);
    }
}
