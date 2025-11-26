using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button mainmenuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject InformationPanel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        SubscribeToEvents();

        mainmenuButton.onClick.AddListener(MainMenu);
        restartButton.onClick.AddListener(Restart);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    void SubscribeToEvents()
    {
        EventManager.OnScoreChanged += UpdateScoreUI;
        EventManager.OnHealthChanged += UpdateHealthUI;
        EventManager.OnPlayerDeath += ShowGameOver;
    }

    void UnsubscribeFromEvents()
    {
        EventManager.OnScoreChanged -= UpdateScoreUI;
        EventManager.OnHealthChanged -= UpdateHealthUI;
        EventManager.OnPlayerDeath -= ShowGameOver;
    }

    void UpdateScoreUI(int newScore)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + newScore.ToString();
    }

    void UpdateHealthUI(int newHealth)
    {
        if (healthText != null)
            healthText.text = "Health: " + newHealth.ToString();
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        finalScoreText.text = GameManager.Instance.CurrentScore.ToString();
        InformationPanel.SetActive(false);
    }
    
    void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
    void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
