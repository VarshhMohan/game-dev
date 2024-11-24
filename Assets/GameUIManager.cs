using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public GameObject deathScreen;   // Reference to the Death Screen Panel
    public GameObject victoryScreen; // Reference to the Victory Screen Panel

    public void Start()
    {
        deathScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }
    public void ShowDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void ShowVictoryScreen()
    {
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

}
