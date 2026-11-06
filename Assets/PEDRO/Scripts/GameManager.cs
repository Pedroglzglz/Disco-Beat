using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private AudioSource musica;
    public bool empezarMusica;
    public ControlNotas bajadaNotas;
    public static GameManager instancia;
    public static float score = 0;
    public static int racha = 0;
    private CanvasManager canvasManager;
    public float scoreNotaNormal = 50;
    public float scoreNotaBien = 100;
    public float scoreNotaPerfecta = 150;
    [SerializeField] private GameObject objetoRayo;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        instancia = this;
        canvasManager = FindAnyObjectByType<CanvasManager>();
        objetoRayo.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!empezarMusica)
        {
            if (Input.anyKeyDown)
            {
                empezarMusica = true;
                bajadaNotas.empezado = true;
                musica.Play();

            }
            
        }
    }

    public void AciertoNormal()
    {
        canvasManager.ActualizarPuntos(scoreNotaNormal);
        ContadorRacha();
        canvasManager.ContadorNotas(1);
        objetoRayo.SetActive(false);
    }

    public void AciertoBien() {
        canvasManager.ActualizarPuntos(scoreNotaBien);
        ContadorRacha();
        canvasManager.ContadorNotas(2);
        objetoRayo.SetActive(false);
        
    }

    public void AciertoPerfecto()
    {
        canvasManager.ActualizarPuntos(scoreNotaPerfecta);
        ContadorRacha();
        canvasManager.ContadorNotas(3);
        objetoRayo.SetActive(true);
    }


    public void Acierto()
    {
        Debug.Log("A tiempo");
        racha += 1;
   
    }

    public void Fallo()
    {
        Debug.Log("Fallado");
        score -= 10;
        racha = 0;
        canvasManager.ActualizarPuntos(score);
        canvasManager.ActualizarRacha(racha);
        objetoRayo.SetActive(false);
    }

    public void ContadorRacha()
    {
        racha += 1;
        if(racha > 10)
        {
            canvasManager.ActualizarRacha(racha);
        }
    }
}
