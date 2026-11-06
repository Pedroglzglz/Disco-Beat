using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundPlayer : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverClip;
    public AudioClip clickClip;
    private AudioSource audioSource;

    void Awake()
    {
        // Puedes tener un único AudioSource en el menú, o por botón
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
        audioSource.volume = 0.8f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverClip != null) audioSource.PlayOneShot(hoverClip);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickClip != null) audioSource.PlayOneShot(clickClip);
    }
}
