using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomos : MonoBehaviour
{
    [SerializeField]
    private float CantidadGnomos;

    [SerializeField]
    private AudioClip up;
    private bool Colisionando = false;

    public GameObject AyudaPlayer;

    [SerializeField]
    private AnimacionGnomo animacion;

    public bool activando = false;
    public bool ActivandoAyuda = false;

    public bool ejecuntado = false;

    [SerializeField]
    public GameObject interfaz;

    public float segundos = 2f;
    private Animator animator;

    void Start()
    {
        AyudaPlayer.SetActive(false);
        animator = GetComponent<Animator>();
        interfaz.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Colisionando == true && !activando && !ejecuntado)
        {
            activando = true;

            StartCoroutine(ActivarConDelay());
            ActivandoAyuda = true;
        }
        else if (ActivandoAyuda == true)
        {
            animator.SetBool("AnimacionSalto", true);
        }
        else
        {
            animator.SetBool("AnimacionSalto", false);
        }
    }

    IEnumerator ActivarConDelay()
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");
        animacion.ActivarAnimacion(true);

        AyudaPlayer.SetActive(false);
        yield return new WaitForSecondsRealtime(segundos);
        ControladorDeSonidos.Instance.EjecutarSonido(up);

        if (interfaz.activeSelf)
        {
            if (!ejecuntado)
            {
                GnomosRecogidos.Instance.SumarGnomos(CantidadGnomos);
                gnomo.SetActive(false);
                activando = false;
                ejecuntado = true;
                ActivandoAyuda = false;
            }
        }
        else
        {
            interfaz.SetActive(true);
            if (!ejecuntado)
            {
                GnomosRecogidos.Instance.SumarGnomos(CantidadGnomos);
                gnomo.SetActive(false);
                activando = false;
                ejecuntado = true;
                ActivandoAyuda = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gnomos") && !ActivandoAyuda)
        {
            AyudaPlayer.SetActive(true);
            Colisionando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("gnomos") && !ActivandoAyuda)
        {
            AyudaPlayer.SetActive(false);
            Colisionando = false;
        }
    }
}
