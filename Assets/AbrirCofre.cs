using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirCofre : MonoBehaviour
{
    private bool isPlayerInRange;
    public GameObject AyudaPlayer;
    public GameObject AyudaPlayer1;

    [SerializeField]
    private GameObject Transicion;

    [SerializeField]
    private Movement Movimiento;

    void Start()
    {
        AyudaPlayer.SetActive(false);
    }

    void Update()
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");
        if (isPlayerInRange == true && Input.GetKeyDown(KeyCode.E) && gnomo == false)
        {
            Transicion.SetActive(true);
            Movimiento.movimientoBloqueado = true;
            Invoke("CargarEscena", 1.6f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");
        if (other.gameObject.CompareTag("Player") && gnomo == false)
        {
            AyudaPlayer.SetActive(false);
            isPlayerInRange = false;
        }
        else
        {
            AyudaPlayer1.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");
        if (other.gameObject.CompareTag("Player") && gnomo == false)
        {
            AyudaPlayer.SetActive(true);
            isPlayerInRange = true;
        }
        else
        {
            AyudaPlayer1.SetActive(true);
        }
    }

    private void CargarEscena()
    {
        SceneManager.LoadScene(8);
    }
}
