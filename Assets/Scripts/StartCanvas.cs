using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] private AudioSource Click;

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
