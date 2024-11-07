using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign the VideoPlayer component in the Inspector
    public string nextSceneName = "CDPlaybackScene"; // Set this to your next scene's name

    private void Start()
    {
        // Ensure the videoPlayer component is assigned
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video finishes
        SceneManager.LoadScene(nextSceneName);
    }
}
