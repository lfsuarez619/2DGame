using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public string nextSceneName = "InterTitles1";  // Next scene
    public float delayBeforeTransition = 3f;       // Delay time in sec before transitioning
    public AudioSource audioSource;                // Reference to the audio source component

    private void Start()
    {
        // Start the transition coroutine to load the next scene after a delay
        StartCoroutine(TransitionToNextSceneAfterDelay());

        // Delay the audio source to start at 3 sec
        StartCoroutine(PlayAudioAtThreeSeconds());
    }

    private IEnumerator TransitionToNextSceneAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeTransition);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator PlayAudioAtThreeSeconds()
    {
        // Wait for 3 secs before starting the audio at 3-sec mark
        yield return new WaitForSeconds(0f);

        // Set the starting time of the audio source to 3 sec
        audioSource.time = 3f;
        audioSource.Play();
    }
}
