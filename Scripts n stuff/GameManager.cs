
using UnityEngine;
using UnityEngine.SceneManagement; // To load next scenes
using UnityEngine.UI;  // For UI elements (e.g., Game Over Text)
using MyGame.Flower;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance to access the GameManager from other scripts

    public GameObject gameOverUI;  // Reference to the Game Over UI panel
    public Text flowersCollectedText;  // UI Text to display collected flowers
    public Text gameOverText;  // Text component to show Game Over message

    private int totalFlowers;  // Total number of flowers in the level
    private int flowersCollected;  // Number of flowers collected so far
    private bool isGameOver = false;

    void Awake()
    {
        // Make sure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOverUI.SetActive(false);  // Hide Game Over UI initially
        flowersCollected = 0;  // Reset collected flowers counter
        totalFlowers = FindObjectsOfType<Flower>().Length;  // Find all flower objects in the level
        UpdateFlowersUI();
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space)) // Press Space to restart the level
        {
            RestartGame();
        }
    }

    // Method to update the number of flowers collected
    public void CollectFlower()
    {
        flowersCollected++;
        UpdateFlowersUI();

        if (flowersCollected >= totalFlowers)
        {
            // All flowers collected, next level logic
            NextLevel();
        }
    }

    // Method to update the UI text showing flowers collected
    private void UpdateFlowersUI()
    {
        flowersCollectedText.text = "Flowers Collected: " + flowersCollected + "/" + totalFlowers;
    }

    // Call this method when the bee dies
    public void BeeDied()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverUI.SetActive(true);  // Show the Game Over screen
            gameOverText.text = "Game Over! Press Space to Restart";
        }
    }

    // Method to go to the next level (scene)
    public void NextLevel()
    {
        // For now, let's just load the next scene
        // Ensure your scenes are added in the Build Settings
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        // Check if there is a next scene, otherwise restart the game
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);  // Load next scene in the build
        }
        else
        {
            Debug.Log("No more levels! Restarting.");
            SceneManager.LoadScene(0);  // Restart from first level (scene index 0)
        }
    }

    // Restart the game (reload the current scene)
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Get total flowers in the current level
    public int GetTotalFlowers()
    {
        return totalFlowers;
    }
}
