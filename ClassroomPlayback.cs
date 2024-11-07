using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDPlayback : MonoBehaviour
{
    public AudioSource whiteNoiseAudio;
    public GameObject pixelFrame;

    private void Start()
    {
        StartCoroutine(PlayCD());
    }

    private IEnumerator PlayCD()
    {
        // Show the pixel frame
        pixelFrame.SetActive(true);

        // Set the start time to 3 seconds into the clip
        whiteNoiseAudio.time = 4f;

        // Play the audio
        whiteNoiseAudio.Play();

        // Wait for 3 seconds (to reach the 6-second mark)
        yield return new WaitForSeconds(3f);

        // Stop the audio and hide the pixel frame
        whiteNoiseAudio.Stop();
        pixelFrame.SetActive(false);
    }
}