using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName = "DialogueScene1";  // Name of next scene
    public float delay = 5f;  // Delay time in secsss

    private void Start()
    {
        // Start the coroutine to load the next scene after the delay
        StartCoroutine(TransitionToNextScene());
    }

    private IEnumerator TransitionToNextScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the specified next scene
        SceneManager.LoadScene(nextSceneName);
    }
}

