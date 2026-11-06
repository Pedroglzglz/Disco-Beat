using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Managers/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public int npcID;
    public DialogueSlide[] beforeItemSlides;
    public DialogueSlide[] afterItemSlides;

    public Sprite npcSprite;
    public string sceneToLoad;  // Nombre de la escena de reto
    public string rewardObjectName;
    public int rewardObjectID;
}
