using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private bool PlayerIsHere = false;
    [SerializeField] private ObjectsManager objectsManagerSO;
    [SerializeField] private string nombre;
    [SerializeField] private int id;

    void Update()
    {
        if (PlayerIsHere && Input.GetKeyDown(KeyCode.E))
        {
            objectsManagerSO.PickedUpObject(nombre, id);
            Destroy(gameObject);
        }   
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsHere = true;
        }
    }
}
