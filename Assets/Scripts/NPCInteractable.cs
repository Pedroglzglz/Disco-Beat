using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [Tooltip ("Es el Identificador que relaciona al NPC con su diálogo correspondiente")]
    [SerializeField] private int npcID;

    [Tooltip ("Hace referencia al Canvas hijo del NPC que contiene el prompt")]
    [SerializeField] private GameObject interactionPrompt;

    [SerializeField] private InteractionManager interactionManagerSO;

    private bool isPlayerInRange = false;


    // Start is called before the first frame update
    void Start()
    {
        interactionPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) )
        {
            interactionManagerSO.NPCInteracted(npcID);
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionPrompt.SetActive(true);
        }        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionPrompt.SetActive(false);
        }        
    }
}
