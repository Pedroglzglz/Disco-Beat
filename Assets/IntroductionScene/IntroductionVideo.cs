using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroductionVideo : MonoBehaviour
{
    [Header("Video")]
    public VideoPlayer videoPlayer;

    [Header("Scene Settings")]
    public int nextSceneIndex = 1;

    [Header("UI")]
    public Button skipButton;

    void Start()
    {
        // Ejecutar cuando termine el vídeo
        videoPlayer.loopPointReached += OnVideoEnd;

        // Escuchar el botón de omitir
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipVideo);
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        LoadNextScene();
    }

    public void SkipVideo()
    {
        videoPlayer.Stop();
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}