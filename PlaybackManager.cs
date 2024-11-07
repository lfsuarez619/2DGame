using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlaybackManager : MonoBehaviour
{
    public TextMeshProUGUI introText;       // Reference to the text that will appear for 3 seconds
    public VideoPlayer videoPlayer;         // Reference to the video player
    public float textDisplayTime = 3f;      // Time to display the text
    public float sceneTransitionTime = 15f; // Time after which to transition to the next scene
    public string nextSceneName = "MinigameScene";  // Name of the next scene

    private void Start()
    {
        // Show the text and hide the video player initially
        introText.enabled = true;
        videoPlayer.gameObject.SetActive(false);

        // Start the sequence to hide text, show the video, and transition scene
        StartCoroutine(DisplayTextThenPlayVideo());
    }

    private IEnumerator DisplayTextThenPlayVideo()
    {
        // Wait for the specified time (3 seconds) with the text visible
        yield return new WaitForSeconds(textDisplayTime);

        // Hide the text and start the video player
        introText.enabled = false;
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();

        // Wait an additional 15 seconds, then load the next scene
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene(nextSceneName);
    }
}