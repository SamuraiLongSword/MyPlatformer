using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private Text HPText;
    [SerializeField] private Text AppleText;
    [SerializeField] private Text AgaricText;
    [SerializeField] private HealthController Player;
    [SerializeField] private Image LevelImage;
    [SerializeField] private GameObject ReplayPanel;

    private void Start()
    {
        GetCanvasText();
    }

    private void Update()
    {
        GetCanvasText();
        CheckPlayerDead();
    }

    private void GetCanvasText()
    {
        HPText.text = "HP   : " + Player.GetHP;
        AppleText.text = ": " + ApplePicker.AppleCounter;
        AgaricText.text = ": " + AgaricCounter.Counter + "/2";
    }

    private void CheckPlayerDead()
    {
        if(Player.GetHP == 0)
        {
            ReplayPanel.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
