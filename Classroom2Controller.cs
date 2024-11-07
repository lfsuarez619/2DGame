using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Classroom2Controller : MonoBehaviour
{
    public TextMeshProUGUI introText;    // Reference to the TextMeshPro text
    public GameObject stillImage;        // Reference to the still image
    public AudioSource audioSource;      // Reference to the audio source on the still image
    public string nextSceneName = "End"; // Name of the final scene to load

    private void Start()
    {
        // Start the display sequence
        StartCoroutine(DisplaySequence());
    }

    private IEnumerator DisplaySequence()
    {
        // Show the text for 3 seconds
        introText.enabled = true;
        yield return new WaitForSeconds(3f);

        // Hide the text and show the still image
        introText.enabled = false;
        stillImage.SetActive(true);

        //Does this even really work?????
        
        // Ensure audio starts from 2 seconds in
        audioSource.time = 2f;      // Set the playback position to 2 seconds
        audioSource.Play();         // Start the audio from the set position

        // Keep the image and audio playing for 2 seconds
        yield return new WaitForSeconds(2f);

        // Transition to the final scene
        SceneManager.LoadScene(nextSceneName);
    }
}