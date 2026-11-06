using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class NeonButtonHover : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] public Material normalMaterial;
    [SerializeField] public Material hoverMaterial;

    public void TriggerHoverEnter()
    {
        text.fontSharedMaterial = hoverMaterial;
    }

    public void TriggerHoverExit()
    {
        text.fontSharedMaterial = normalMaterial;
    }
}

