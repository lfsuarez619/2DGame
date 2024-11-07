using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlaybackManager1 : MonoBehaviour
{
    public VideoPlayer videoPlayer;         // Reference to the VideoPlayer component
    public string nextSceneName = "MinigameScene";  // Name of the next scene

    private void Start()
    {
        // Subscribe to the video player's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene when the video ends
        SceneManager.LoadScene(nextSceneName);
    }
}

