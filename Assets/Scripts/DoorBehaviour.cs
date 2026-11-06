using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private ObjectsManager objectsManagerSO;
    [SerializeField] private int requiredObjectID;
    [SerializeField] private bool disableOnlyCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        if (objectsManagerSO.HasCollected(requiredObjectID))
        {
            if (disableOnlyCollider)
            {
                Collider col = GetComponent<Collider>();
                if (col != null)
                {
                    col.enabled = false;
                }

                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
