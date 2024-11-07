using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SurveillanceGame : MonoBehaviour
{
    public Text timerText;             // UI Text to display time
    public Text clicksLeftText;        // UI Text to display remaining clicks
    public int maxClicks = 3;          // Maximum clicks allowed
    public float maxTime = 90f;        // Max time in seconds
    public GameObject endGameObject;   // The GameObject that will end the game if clicked
    public string nextSceneName = "Classroom2";  // Name of the next scene to load

    private int remainingClicks;
    private float remainingTime;
    private bool gameEnded = false;

    private void Start()
    {
        remainingClicks = maxClicks;
        remainingTime = maxTime;

        UpdateUI();
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        while (remainingTime > 0 && remainingClicks > 0 && !gameEnded)
        {
            remainingTime -= Time.deltaTime;
            UpdateUI();
            yield return null;
        }

        // End the game when time or clicks run out
        EndGame();
    }

    private void UpdateUI()
    {
        // Ensure the timer and clicks left are displayed correctly
        timerText.text = "Time Left: " + Mathf.CeilToInt(remainingTime).ToString();
        clicksLeftText.text = "Clicks Left: " + remainingClicks.ToString();
    }

    private void EndGame()
    {
        // Set the gameEnded flag to true to prevent further clicks
        gameEnded = true;

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
        Debug.Log("Game Over - Transitioning to Classroom2");
    }

    private void OnMouseDown()
    {
        if (!gameEnded && remainingClicks > 0)
        {
            // Detect the clicked object
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("OutOfPlace"))
                {
                    // Handle successful click on an out-of-place object
                    remainingClicks--;
                    
                    // Disable or hide the object to indicate it’s found
                    hit.collider.gameObject.SetActive(false);
                }
                else if (hit.collider.gameObject == endGameObject)
                {
                    // Handle click on specific GameObject to end the game
                    EndGame();
                    return;
                }
                else
                {
                    // An incorrect click will do this
                    remainingClicks--;
                }

                UpdateUI();

                if (remainingClicks <= 0)
                {
                    EndGame();
                }
            }
        }
    }
}
