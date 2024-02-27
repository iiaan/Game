using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomos : MonoBehaviour
{
    [SerializeField]
    private float CantidadGnomos;

    [SerializeField]
    private GnomosRecogidos puntaje;

    void Start() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");

        if (collision.CompareTag("gnomos"))
        {
            puntaje.SumarGnomos(CantidadGnomos);
            Destroy(gnomo);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
}
