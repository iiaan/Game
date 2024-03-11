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

    public float delay = 2.0f;

    public bool activando = false;
    public bool ActivandoAyuda = false;

    public bool ejecuntado = false;

    [SerializeField]
    public GameObject interfaz;

    void Start()
    {
        AyudaPlayer.SetActive(false);

        interfaz.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Colisionando == true && !activando && !ejecuntado)
        {
            activando = true;
            ActivandoAyuda = true;
            StartCoroutine(ActivarConDelay());
        }
    }

    IEnumerator ActivarConDelay()
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");
        animacion.ActivarAnimacion(true);
        AyudaPlayer.SetActive(false);
        yield return new WaitForSeconds(2f);
        ControladorDeSonidos.Instance.EjecutarSonido(up);
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
