using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneTrigger : MonoBehaviour
{
    public KeyCode laneKey; // Tecla asignada
    private NoteBehaviour noteInZone; // Nota detectada dentro del trigger

    void Update()
    {
        if (noteInZone != null && Input.GetKeyDown(laneKey))
        {
            bool success = noteInZone.ValidatePulsation();
            if (success)
            {
                Debug.Log($"✅ ¡Acertaste en lane [{laneKey}]!");
                noteInZone = null; // Importante: limpiamos la referencia
            }
            else
            {
                Debug.Log($"❌ Pulsaste en lane [{laneKey}] pero fuera del margen");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            noteInZone = other.GetComponent<NoteBehaviour>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note") && other.GetComponent<NoteBehaviour>() == noteInZone)
        {
            noteInZone = null;
        }
    }
}