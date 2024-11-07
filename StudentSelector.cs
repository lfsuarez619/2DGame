using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudentSelector : MonoBehaviour
{
    // Name of the scene to load after selection
    public string nextSceneName = "NewScene";

    private void OnMouseDown()
    {
        // Load the specified new scene when this object is clicked
        SceneManager.LoadScene(nextSceneName);
    }
}
