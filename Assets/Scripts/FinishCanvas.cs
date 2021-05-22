using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCanvas : MonoBehaviour
{
    public void StartOver()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
