using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    public float fallSpeed = 1.0f; // Velocidad de caída
    private float pulsationMargin = 1.0f; // Margen de validación en Y
    private bool canBeDestroyedByTrigger = false; // Se activa al pasar por el PulsationPoint

    void Update()
    {
        // Baja constantemente
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    public bool ValidatePulsation()
    {
        // Comprobamos si la posición Y está dentro del margen
        if (Mathf.Abs(transform.position.y) <= pulsationMargin)
        {
            Debug.Log($"✅ ¡Pulsación correcta! Y = {transform.position.y:F2}");
            Destroy(gameObject);
            return true;
        }
        else
        {
            Debug.Log($"❌ Pulsación fuera de margen. Y = {transform.position.y:F2}");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PulsationPoint"))
        {
            canBeDestroyedByTrigger = true;
            Debug.Log("[NOTE] Entró en el punto de pulsación.");
        }
        else if (other.CompareTag("MissZone") && canBeDestroyedByTrigger)
        {
            Debug.Log($"💀 ¡Nota fallada! Se destruye automáticamente en Y={transform.position.y:F2}");
            Destroy(gameObject);
        }
    }
}