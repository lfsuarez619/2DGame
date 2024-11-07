using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished; 
 		// When the video ends
    }

 	//THIS DOESNT WORK!!!!
    void Update()
    {
        // Check if the Spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        LoadMainGameScene();
    }

    private void SkipVideo()
    {
        // Stops the video and loads the main game scene
        videoPlayer.Stop();
        LoadMainGameScene();
    }

    private void LoadMainGameScene()
    {
        // Replace "GameScene" with your main game scene's name
        SceneManager.LoadScene("GameScene");
    }
}
