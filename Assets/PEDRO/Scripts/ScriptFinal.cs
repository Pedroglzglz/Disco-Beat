using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptFinal : MonoBehaviour
{
    [SerializeField] private Canvas pantallaFinal;
    [SerializeField] private TMP_Text textoFinal;
    [SerializeField] private float scoreMinimo;
    private CanvasManager canvasManager;
    private bool haGanado = false;

    // CAMPOS AÑADIDOS POR ADRI
    [SerializeField] private ActiveChallengeData activeChallengeSO;
    [SerializeField] private ObjectsManager objectsManagerSO;
    //[SerializeField] private string nombreDelObjeto;
    //[SerializeField] private int idDelObjeto;

    private void Start()
    {
        pantallaFinal.gameObject.SetActive(false);
        canvasManager = FindAnyObjectByType<CanvasManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perfect"))
        {
            pantallaFinal.gameObject.SetActive(true);
            Debug.Log("Tocado Final");
            CondicionFinal();
        }
    }
    public void VolverAEscenaPrincipal()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SceneAdri");
    }

    public void CondicionFinal()
    {
        if (canvasManager.scoreInterno < scoreMinimo)
        {
            textoFinal.text = "Inténtalo de nuevo";
            haGanado = false;
        }
        else
        {
            textoFinal.text = "¡Conseguido!";
            haGanado = true;

            int id = activeChallengeSO.objectIDToGrant;
            string nombre = activeChallengeSO.objectNameToGrant;

            if (id >= 0 && !string.IsNullOrEmpty(nombre))
            {
                objectsManagerSO.PickedUpObject(nombre, id);
                Debug.Log($"Objeto concedido: {nombre} con ID {id}");
                activeChallengeSO.Clear();
            }
            else
            {
                Debug.LogWarning("⚠️ ActiveChallengeData vacío. No se otorgó ningún objeto.");
            }
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continuar()
    {
        if (haGanado)
        {
            // Ir a la escena principal            
            UnityEngine.SceneManagement.SceneManager.LoadScene("SceneAdri");
        }
        else
        {
            // Repetir esta misma escena
            var escenaActual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadScene(escenaActual);
        }
    }

}
