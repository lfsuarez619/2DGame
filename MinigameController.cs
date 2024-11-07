using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MinigameController : MonoBehaviour
{
    public float maxTime = 90f;          // Max time in seconds
    public int maxClicks = 3;            // Maximum number of clicks
    public GameObject targetArea;        // Reference to the clickable area
    public string nextSceneName = "Classroom2"; // Name of the next scene to load

    private int remainingClicks;
    private float remainingTime;
    private bool gameEnded = false;

    private void Start()
    {
        // Initialize the timer and click counter
        remainingClicks = maxClicks;
        remainingTime = maxTime;

        // Start the timer
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        // Countdown loop for the timer
        while (remainingTime > 0 && remainingClicks > 0 && !gameEnded)
        {
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        // End the game when time or clicks run out
        EndGame();
    }

    private void EndGame()
    {
        // Ensure game ends only once
        if (gameEnded) return;
        gameEnded = true;

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
        Debug.Log("Game Over - Transitioning to Classroom2");
    }

    private void Update()
    {
        // Detect mouse clicks
        if (Input.GetMouseButtonDown(0) && !gameEnded && remainingClicks > 0)
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == targetArea)
        {
            // Correct click: end the game and load the next scene
            EndGame();
        }
        else
        {
            // Incorrect click: decrease the click count
            remainingClicks--;

            // Check if clicks are exhausted
            if (remainingClicks <= 0)
            {
                EndGame();
            }
        }
    }
}
