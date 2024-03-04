using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomos : MonoBehaviour
{
    [SerializeField]
    private float CantidadGnomos;

    [SerializeField]
    private GnomosRecogidos puntaje;

    [SerializeField]
    private AudioClip up;
    private bool Colisionando = false;

    public GameObject AyudaPlayer;

    void Start()
    {
        AyudaPlayer.SetActive(false);
    }

    void Update()
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");

        if (Input.GetKeyDown(KeyCode.E) && Colisionando == true)
        {
            AyudaPlayer.SetActive(false);
            ControladorDeSonidos.Instance.EjecutarSonido(up);
            puntaje.SumarGnomos(CantidadGnomos);
            Destroy(gnomo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gnomos"))
        {
            AyudaPlayer.SetActive(true);
            Colisionando = true;
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
}
