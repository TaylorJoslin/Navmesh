using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int pointsToWin = 5;
   // public int pointsToLose = 3; // Add a lose condition
    public TMP_Text winText;
    public TMP_Text loseText;

    private int currentPoints = 0;
    private bool gameEnded = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { RestartGame(); }
    }

    public void AddPoints(int points)
    {
        if (!gameEnded)
        {
            currentPoints += points;
            CheckWinCondition();
            //CheckLoseCondition(); // Check for lose condition after adding points
        }
    }

    private void CheckWinCondition()
    {
        if (currentPoints >= pointsToWin)
        {
            Time.timeScale = 0;
            gameEnded = true;
            ShowWinUI();

            if (Input.GetKeyDown(KeyCode.R)) { RestartGame(); }
        }
    }

    public void LoseCondition()
    {

        Time.timeScale = 0;
        gameEnded = true;
        ShowLoseUI();

        if (Input.GetKeyDown(KeyCode.R)) { RestartGame(); }

    }

    private void ShowWinUI()
    {
        winText.gameObject.SetActive(true);
        winText.text = "You Win!";
        // You can add additional UI elements or animations here
    }

    private void ShowLoseUI()
    {
        loseText.gameObject.SetActive(true);
        loseText.text = "You Lose!";
        // You can add additional UI elements or animations here
    }

    public void RestartGame()
    {
        // Reset game state
        currentPoints = 0;
        gameEnded = false;
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
