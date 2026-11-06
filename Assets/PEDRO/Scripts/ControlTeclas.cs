using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTeclas : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    [SerializeField] private Sprite teclaSinPulsar;
    [SerializeField] private Sprite teclaPulsada;
    [SerializeField] private KeyCode tecla;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            sRenderer.sprite = teclaPulsada;
        }
        if(Input.GetKeyUp(tecla)) 
        {
            sRenderer.sprite = teclaSinPulsar;
        }
    }
}
