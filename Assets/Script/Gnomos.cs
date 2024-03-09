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

    void Start()
    {
        AyudaPlayer.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Colisionando == true)
        {
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

        GnomosRecogidos.Instance.SumarGnomos(CantidadGnomos);
        gnomo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gnomos"))
        {
            AyudaPlayer.SetActive(true);
            Colisionando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("gnomos"))
        {
            AyudaPlayer.SetActive(false);
            Colisionando = false;
        }
    }
}
