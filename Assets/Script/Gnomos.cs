using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomos : MonoBehaviour
{
    [SerializeField]
    private float CantidadGnomos;

    [SerializeField]
    private GnomosRecogidos puntaje;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");

        if (collision.collider.CompareTag("gnomos"))
        {
            puntaje.SumarGnomos(CantidadGnomos);
            Destroy(gnomo);
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
