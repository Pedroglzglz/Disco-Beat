using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{
    [SerializeField] private ObjectsManager objectsManagerSO;

    [Header("Popup UI")]
    [SerializeField] private GameObject PickedUpObjectPopUp;
    [SerializeField] private Animator objectPickUpAnimator; 
    [SerializeField] private TextMeshProUGUI congratsText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Image pickupObjectImage;
    [SerializeField] private PlayerMovement playerMovement;

    //[Header("Lista de objetos")]
    [System.Serializable]
    public class ObjectData
    {
        public string objectName;
        public Sprite objectSprite;
        public GameObject ncObjectImage;
        public GameObject cObjectImage;
    }

    [SerializeField] private List<ObjectData> objectsList;
    private ObjectData currentObject;


    private void OnEnable ()
    {
        objectsManagerSO.OnPickedUpObject += ShowPickUpPopUp;
    }

    private void OnDisable ()
    {
        objectsManagerSO.OnPickedUpObject -= ShowPickUpPopUp;
    }
    
    private void Start()
    {
        // Mostramos el último objeto recogido si existe
        List<string> recogidos = objectsManagerSO.GetCollectedNames();
        if (recogidos.Count > 0)
        {
            string ultimo = recogidos[recogidos.Count - 1];
            ShowPickUpPopUp(ultimo); // Esto lanza el PopUp como si acabara de recogerse
        }
        
        // Al volver a escena, revisar si hay objetos ya recogidos y mostrarlos
        foreach (string collectedName in objectsManagerSO.GetCollectedNames())
        {
            ActivateObjectFromName(collectedName);
        }
    }

    private void ShowPickUpPopUp(string objectName)
    {
        currentObject = objectsList.Find(obj => obj.objectName == objectName);

        if (currentObject == null)
        {
            Debug.LogWarning($"No se encontró el objeto con nombre {objectName}");
            return;
        }

        pickupObjectImage.sprite = currentObject.objectSprite;
        congratsText.text = $"¡Enhorabuena! Has obtenido {currentObject.objectName}";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovement.canMove = false;

        PickedUpObjectPopUp.SetActive(true);
        congratsText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);

        objectPickUpAnimator.Play("PickedUpObject");
    }

    public void ShowTextAndButton()
    {
        congratsText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(FinishPopup);
    }

    private void FinishPopup()
    {
        PickedUpObjectPopUp.SetActive(false);
        ActivateObjectInInventory();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.canMove = true;
    }

    public void ActivateObjectInInventory()
    {
        if (currentObject.ncObjectImage != null)
        {
            currentObject.ncObjectImage.SetActive(false);
        }

        if (currentObject.cObjectImage != null)
        {
            currentObject.cObjectImage.SetActive(true);
        }
    }

    private void ActivateObjectFromName(string objectName)
    {
        ObjectData obj = objectsList.Find(o => o.objectName == objectName);
        if (obj != null)
        {
            if (obj.ncObjectImage != null)
                obj.ncObjectImage.SetActive(false);
            if (obj.cObjectImage != null)
                obj.cObjectImage.SetActive(true);
        }
    }

    public void OnContinueButtonClicked()
    {
        PickedUpObjectPopUp.SetActive(false);
    }
}
