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

    [SerializeField] private Text EndLvlAppleText;
    [SerializeField] private Text EndLvlEnemyText;
    [SerializeField] private GameObject EndLvlPanel;

    [SerializeField] private AudioSource WinSound;
    [SerializeField] private AudioSource ClickSound;

    private PlayerInput _input;

    private void Start()
    {
        GetCanvasText();
        _input = Player.GetComponent<PlayerInput>();
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

        EndLvlAppleText.text = "Apples collected: " + ApplePicker.AppleCounter;
        EndLvlEnemyText.text = "Enemies destroyed: " + AgaricCounter.Counter;
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

    public void ToMenu()
    {
        SceneManager.LoadScene("_StartScene_");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void EndLvlPopup()
    {
        WinSound.Play();
        EndLvlPanel.SetActive(true);
        _input.ChangeInputAccess(false);
    }

    public void ClickPlay()
    {
        ClickSound.Play();
    }
}
