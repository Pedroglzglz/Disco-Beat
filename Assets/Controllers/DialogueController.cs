using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    [Header("MANAGERS")]
    [SerializeField] private InteractionManager interactionManagerSO;
    [SerializeField] private DialogueData[] allDialogues;
    [SerializeField] private ObjectsManager objectManagerSO;
    [SerializeField] private ActiveChallengeData activeChallengeSO;

    [Header("UI ELEMENTS")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image npcImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject choiceButtonPanel;
    [SerializeField] private Button acceptButton;
    [SerializeField] private Button rejectButton;

    [SerializeField] private PlayerMovement playerMovement;
    private DialogueData currentDialogueData;
    private DialogueSlide[] currentSlides;
    private int currentSlideIndex = 0;
    //private List<int> collectedObjectIDs = new List<int>();

    private void OnEnable()
    {
        interactionManagerSO.OnNPCInteracted += StartDialogue;
        //objectManagerSO.OnPickedUpObjectForNPC += SaveObject;
    }

    private void OnDisable()
    {
        interactionManagerSO.OnNPCInteracted -= StartDialogue;
        //objectManagerSO.OnPickedUpObjectForNPC -= SaveObject;
    }

    /*
    private void SaveObject(int objectID)
    {
        if (!collectedObjectIDs.Contains(objectID))
        {
            collectedObjectIDs.Add(objectID);
            Debug.Log("Objeto recogido con ID: " + objectID);
        }
    }
    */

    private void StartDialogue(int npcID)
    {
        currentDialogueData = GetDialogueData(npcID);
        
        if (currentDialogueData != null)
        {
            npcImage.sprite = currentDialogueData.npcSprite;
            
            dialoguePanel.SetActive(true);
            currentSlideIndex = 0;

            if (objectManagerSO.HasCollected(npcID))
            {
                currentSlides = currentDialogueData.afterItemSlides;
            }
            else
            {
                currentSlides = currentDialogueData.beforeItemSlides;
            }

            ShowSlide();
            EnterDialogueMode();
        }
        else
        {
            Debug.LogWarning($"No se encontró diálogo para NPC ID: {npcID}");
        }
    }

    private void EnterDialogueMode()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Time.timeScale = 0f;
        playerMovement.canMove = false;
    }



    private DialogueData GetDialogueData(int id)
    {
        foreach (DialogueData data in allDialogues)
        {
            if (data.npcID == id)
            {
                return data;
            }
        }
        return null;
    }

    private void ShowSlide()
    {

        if (currentSlideIndex < currentSlides.Length)
        {
            DialogueSlide slide = currentSlides[currentSlideIndex];
            dialogueText.text = slide.dialogueText;

            nextButton.gameObject.SetActive(!slide.showChoices);
            choiceButtonPanel.SetActive(slide.showChoices);
        }
        else
        {
            EndDialogue();
        }
    }

    public void OnClickNext()
    {
        currentSlideIndex++;
        ShowSlide();
    }

    public void OnClickAccept()
    {
        Debug.Log("Reto aceptado");
        EndDialogue();

        if (currentDialogueData != null)
        {
            if (!string.IsNullOrEmpty(currentDialogueData.sceneToLoad))
            {
                activeChallengeSO.objectIDToGrant = currentDialogueData.rewardObjectID;
                activeChallengeSO.objectNameToGrant = currentDialogueData.rewardObjectName;

                SceneManager.LoadScene(currentDialogueData.sceneToLoad);
            }
            else
            {
                Debug.Log("Este NPC no lanza escena. Solo diálogo.");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró DialogueData activo al aceptar reto.");
        }
    }

    public void OnClickReject()
    {
        Debug.Log("Reto rechazado");
        EndDialogue();
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        choiceButtonPanel.SetActive(false);
        currentSlides = null;
        ExitDialogueMode();
    }
    
    private void ExitDialogueMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Time.timeScale = 1f;
        playerMovement.canMove = true;
    }
}
