using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textoScore;
    [SerializeField] private TMP_Text textoRacha;
    [SerializeField] private TMP_Text textoNotas;
    public float scoreInterno;
    
    private int normal = 0;
    private int bien = 0;
    private int perfecto = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreInterno = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scoreInterno);    
    }

    public void ActualizarPuntos(float score)
    {
        scoreInterno += score;
        textoScore.text = scoreInterno.ToString();
        
    }
    public void ActualizarRacha(int racha)
    {
        textoRacha.text = "Racha: " + racha.ToString();
        if(racha <= 10)
        {
            textoRacha.text = "";
        }
    }

    public void ContadorNotas(int numero)
    {
        
        if(numero == 1)
        {
            normal += 1;
            textoNotas.text = "Normal: " + normal.ToString() + "\nBien: " + bien.ToString() + "\nPerfecto: " + perfecto.ToString();       
        }
        if(numero == 2)
        {
            bien += 1;
            textoNotas.text = "Normal: " + normal.ToString() + "\nBien: " + bien.ToString() + "\nPerfecto: " + perfecto.ToString();
        }
        if(numero == 3)
        {
            perfecto += 1;
            textoNotas.text = "Normal: " + normal.ToString() + "\nBien: " + bien.ToString() + "\nPerfecto: " + perfecto.ToString();
        }
    }
}
