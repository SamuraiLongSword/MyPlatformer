using System.Collections;
using UnityEngine;

public class BoxToMoveSpawn : MonoBehaviour
{
    [SerializeField] private GameObject BoxToMovePrefab;
    [SerializeField] private GameObject BoxToMoveOnScene;

    private GameObject _currentBox;

    void Start()
    {
        _currentBox = BoxToMoveOnScene;
    }

    void Update()
    {
        BoxOnSceneChecker();
    }

    private void BoxOnSceneChecker()
    {
        if (_currentBox != null) // Checking if the box to move is on scene
        {
            return;
        }
        else
        {
            StartCoroutine(InstantiateAfterDestroy()); // if the box has been destroyed instantiates a new one with 5 seconds delay
        }
    }

    private IEnumerator InstantiateAfterDestroy()
    {
        _currentBox = Instantiate(BoxToMovePrefab, transform.position, Quaternion.identity);
        _currentBox.SetActive(false);

        yield return new WaitForSeconds(5);

        _currentBox.SetActive(true);
    }
}
