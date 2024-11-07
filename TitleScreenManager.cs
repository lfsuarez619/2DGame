using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the intro scene to play the video
        SceneManager.LoadScene("IntroScene");
    }
}
