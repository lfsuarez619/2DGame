using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public GameObject panelWithText; // Reference to the panel with text

    private void Start()
    {
        // Start the sequence to show and hide the panel
        StartCoroutine(DisplayPanel());
    }

    private IEnumerator DisplayPanel()
    {
        // Show the panel
        panelWithText.SetActive(true);

        // Wait for 2 secs
        yield return new WaitForSeconds(2f);

        // Hide the panel
        panelWithText.SetActive(false);
    }
}
