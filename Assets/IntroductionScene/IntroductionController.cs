using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class IntroductionController : MonoBehaviour
{
    [Header("UI Elements")]
    public Image sceneImage;
    public Button nextButton;

    [Header("Assets")]
    public List<Sprite> sceneSprites;
    public List<AudioClip> sceneAudio;

    [Header("Audio Sources")]
    public AudioSource sfxAudioSource;        // Para sonidos específicos de cada escena
    public AudioSource ambientAudioSource;    // Para la lluvia de fondo

    [Header("Settings")]
    public float sceneDuration = 3f;
    public Vector3 zoomAmount = new Vector3(1.05f, 1.05f, 1f);

    private int currentSceneIndex = 0;
    private bool inputReceived = false;

    private void Start()
    {
        // Reproducir audio de fondo en loop
        if (sceneAudio.Count > 0 && ambientAudioSource != null)
        {
            ambientAudioSource.clip = sceneAudio[0]; // Lluvia
            ambientAudioSource.loop = true;
            ambientAudioSource.Play();
        }

        nextButton.onClick.AddListener(OnNextClicked);
        StartCoroutine(PlayScene(currentSceneIndex));
    }

    void OnNextClicked()
    {
        inputReceived = true;
    }

    IEnumerator PlayScene(int index)
    {
        if (index >= sceneSprites.Count)
        {
            LoadNextScene();
            yield break;
        }

        sceneImage.sprite = sceneSprites[index];
        sceneImage.rectTransform.localScale = Vector3.one;
        inputReceived = false;

        float elapsedTime = 0f;

        // Play sound
        if (index < sceneAudio.Count && sceneAudio[index] != null)
        {
            sfxAudioSource.clip = sceneAudio[index];
            sfxAudioSource.Play();
        }

        while (elapsedTime < sceneDuration)
        {
            if (inputReceived)
                break;

            float t = elapsedTime / sceneDuration;
            sceneImage.rectTransform.localScale = Vector3.Lerp(Vector3.one, zoomAmount, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentSceneIndex++;

        if (currentSceneIndex >= sceneSprites.Count)
        {
            LoadNextScene();
        }
        else
        {
            StartCoroutine(PlayScene(currentSceneIndex));
        }
    }

    void LoadNextScene()
    {
        ambientAudioSource.Stop(); // Detener la lluvia al cambiar de escena
        SceneManager.LoadScene(2); // Cargar la escena 2
    }
}