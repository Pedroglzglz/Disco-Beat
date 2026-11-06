using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNotas : MonoBehaviour
{
    [SerializeField] private float tempoCancion;
    public bool empezado;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        tempoCancion /= 60f;
        empezado = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (empezado)
        {

            foreach(Transform hijo in transform)
            {
                hijo.Translate(new Vector3(1, 0, 0).normalized * tempoCancion * Time.deltaTime, Space.World);
            }
            
        }
    }
}
