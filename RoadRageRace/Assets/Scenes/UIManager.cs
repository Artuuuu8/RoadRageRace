using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text resultText;
    public Button restartButton;

    void Start()
    {
        // Hide the result UI at start
        resultText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        // Add a listener to the restart button
        restartButton.onClick.AddListener(RestartGame);
    }

    // Call this method when the race is finished
    public void ShowFinish(string message)
    {
        resultText.text = message;
        resultText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Restart the scene/game
    void RestartGame()
    {
        AudioManager.Instance.StopFinishSound();
        AudioManager.Instance.PlayRestartSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}