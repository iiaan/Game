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

    public float segundos = 1.5f;
    private Animator animator;
    private Rigidbody2D rb;

    public Movement moviemiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AyudaPlayer.SetActive(false);
        animator = GetComponent<Animator>();
        interfaz.SetActive(false);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Colisionando == true && !activando && !ejecuntado)
        {
            moviemiento.movimientoBloqueado = true;
            activando = true;

            StartCoroutine(ActivarConDelay());
            ActivandoAyuda = true;
        }
        else if (ActivandoAyuda == true && !ejecuntado)
        {
            StartCoroutine(ActivarAnimacionSalto());
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
                rb.bodyType = RigidbodyType2D.Dynamic;
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
                rb.bodyType = RigidbodyType2D.Dynamic;
                GnomosRecogidos.Instance.SumarGnomos(CantidadGnomos);
                gnomo.SetActive(false);
                activando = false;
                ejecuntado = true;
                ActivandoAyuda = false;
            }
        }

        yield return new WaitForSecondsRealtime(2f);
        animator.SetBool("AnimacionSalto", false);
        yield return new WaitForSecondsRealtime(1f);
        moviemiento.movimientoBloqueado = false;
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

    IEnumerator ActivarAnimacionSalto()
    {
        ActivandoAyuda = false;
        yield return new WaitForSecondsRealtime(segundos);
        AnimacionSalto();
    }

    private void AnimacionSalto()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        animator.SetBool("AnimacionSalto", true);
    }
}
