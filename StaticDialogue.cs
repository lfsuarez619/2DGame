using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaticDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // Reference to the Text component for the dialogue
    public float displayTime = 3f;        // Time to display the text

    private void Start()
    {
        // Enable the dialogue text directly for testing
        dialogueText.enabled = true;

        // Automatically hide the text after the display time
        Invoke(nameof(HideDialogue), displayTime);
    }

    private void HideDialogue()
    {
        // Hide the dialogue text
        dialogueText.enabled = false;
    }
}
