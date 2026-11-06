using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotasMastil : MonoBehaviour
{

    private bool puedeSerPulsado;
    //private bool pulsado;
    
    public KeyCode teclaPulsar;
    
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(teclaPulsar))
        {
            
            if (puedeSerPulsado)
            {
                
                gameObject.SetActive(false);
                

                if (transform.position.x >= -0.8f && transform.position.x < -0.3f)
                {
                    Debug.Log("Bien");
                    GameManager.instancia.AciertoBien();
                    
                }
                else if(transform.position.x >= -0.3 && transform.position.x < 0.5f)
                {
                    Debug.Log("Perfecto");
                    GameManager.instancia.AciertoPerfecto();
                    
                }
                else if(transform.position.x >=0.5f && transform.position.x < 1)
                {
                    Debug.Log("Normal");
                    GameManager.instancia.AciertoNormal();
                    
                }
                
            }            
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perfect"))
        {
            puedeSerPulsado = true;
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Perfect"))
        {
            puedeSerPulsado = false;
            GameManager.instancia.Fallo();
        }
    }
}
