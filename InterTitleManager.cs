using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class InterTitleManager : MonoBehaviour
{
    public TextMeshProUGUI interTitleText;       // Initial inter-title text
    public Button option1Button;                 // Reference to Option 1 button
    public Button option2Button;                 // Reference to Option 2 button
    public Button option3Button;                 // Reference to Option 3 button
    public TextMeshProUGUI finalInterTitleText;  // Final inter-title text
    public float interTitleDisplayTime = 3f;     // Time to display initial inter-title
    public string nextSceneName = "Playback2";   // Name of the next scene to load

    private void Start()
    {
        // Initially hide the final inter-title and disable dialogue options
        finalInterTitleText.enabled = false;
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        option3Button.gameObject.SetActive(false);

        // Show the initial inter-title and start the sequence
        StartCoroutine(DisplayInitialInterTitle());
    }

    private IEnumerator DisplayInitialInterTitle()
    {
        // Display the initial inter-title for a few seconds
        yield return new WaitForSeconds(interTitleDisplayTime);

        // Hide the initial inter-title
        interTitleText.enabled = false;

        // Enable dialogue options after the initial inter-title
        EnableDialogueOptions();
    }

    private void EnableDialogueOptions()
    {
        // Make the dialogue option buttons visible and interactable
        option1Button.gameObject.SetActive(true);
        option2Button.gameObject.SetActive(true);
        option3Button.gameObject.SetActive(true);

        // Add "listeners" to each button to handle selection
        option1Button.onClick.AddListener(() => HandleOptionSelected());
        option2Button.onClick.AddListener(() => HandleOptionSelected());
        option3Button.onClick.AddListener(() => HandleOptionSelected());
    }

    private void HandleOptionSelected()
    {
        // Disable all buttons after an option is selected
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        option3Button.gameObject.SetActive(false);

        // Show the final inter-title
        finalInterTitleText.enabled = true;

        // Start the transition to the next scene after 3 seconds
        StartCoroutine(TransitionToNextScene());
    }

    private IEnumerator TransitionToNextScene()
    {
        yield return new WaitForSeconds(3f); // Wait 3 seconds
        SceneManager.LoadScene(nextSceneName); // Load Playback2 scene
    }
}
