using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirCofre : MonoBehaviour
{
    private bool isPlayerInRange;
    public GameObject AyudaPlayer;

    void Start()
    {
        AyudaPlayer.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            Invoke("CargarEscena", 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AyudaPlayer.SetActive(false);
            isPlayerInRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AyudaPlayer.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void CargarEscena()
    {
        SceneManager.LoadScene(8);
    }
}
