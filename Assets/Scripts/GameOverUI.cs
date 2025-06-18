using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverBackground;
    [SerializeField] private Button _playAgain;
    [SerializeField] private Button _exit;

    void Start()
    {
        GameManager.Instance.GameIsOver += GameIsOver;
        _playAgain.onClick.AddListener(OnPlayAgainButtonClicked);
        _exit.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private void OnPlayAgainButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    private void GameIsOver()
    {
        _gameOverBackground.SetActive(true);
    }
}
