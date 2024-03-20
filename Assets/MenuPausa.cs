using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPausa;

    [SerializeField]
    private GameObject menuPausaVolumen;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private Movement Movimiento;
    private bool juegoPausado = false;

    public bool DentroDeVolumen;

    public void Start()
    {
        menuPausa.SetActive(false);
        menuPausaVolumen.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
                if (Input.GetKeyDown(KeyCode.Escape) && !DentroDeVolumen)
                {
                    Volver();
                }
            }
        }
    }

    public void Pausa()
    {
        Movimiento.movimientoBloqueado = true;
        Time.timeScale = 0f;
        juegoPausado = true;
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Movimiento.movimientoBloqueado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        juegoPausado = false;
    }

    public void Volumen()
    {
        Debug.Log("aqui");
        DentroDeVolumen = false;
        juegoPausado = false;
        menuPausaVolumen.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Volver()
    {
        menuPausaVolumen.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }
}
