using UnityEngine;
using UnityEngine.SceneManagement;  // Needed to reload scenes

public class WinUIController : MonoBehaviour
{
    public GameObject winPanel;

    private void Start()
    {
        // Makes sure the panel is hidden when the game starts
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void ShowWinScreen()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Pause the game so the player stops moving
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        // Un-pause the game
        Time.timeScale = 1f;

        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
