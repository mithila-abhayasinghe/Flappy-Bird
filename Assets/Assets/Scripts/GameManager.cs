using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    [Header("UI References")]
    public GameObject pauseMenu;       // Reference to the pause menu
    public GameObject gameOverScreen;  // Reference to the game over screen

    [Header("Game Settings")]
    public bool isGamePaused = false;  // Tracks if the game is paused
    public bool isGameOver = false;    // Tracks if the game is over

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check for pause input (optional: you can bind this to a key if needed)
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            TogglePause();
        }
    }

    // Toggle the pause menu on/off
    public void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    // Pause the game
    private void PauseGame()
    {
        Time.timeScale = 0f; // Freeze time
        pauseMenu.SetActive(true); // Show the pause menu
    }

    // Resume the game
    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        pauseMenu.SetActive(false); // Hide the pause menu
    }

    // Show the game over screen
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Freeze time
        gameOverScreen.SetActive(true); // Show the game over screen
    }

    // Restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Quit the game
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop the game in the editor
        #else
            Application.Quit(); // Quit the application in a build
        #endif
    }
}
