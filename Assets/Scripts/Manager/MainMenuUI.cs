using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        startButton.onClick.AddListener(() => { SceneManager.LoadScene("Game"); });
        quitButton.onClick.AddListener(() => { Application.Quit(); });
    }
}
