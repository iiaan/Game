using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField]
    public GameObject AyudaPasarNivel;

    void Start()
    {
        AyudaPasarNivel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        {
            GameObject interfaz = GameObject.FindGameObjectWithTag("NumeroGnomos");
            GameObject gnomo = GameObject.FindGameObjectWithTag("gnomos");

            if (gnomo == false)
            {
                if (collision.CompareTag("Capsule"))
                {
                    CargarEscena(2);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule2"))
                {
                    Debug.Log("DENTRO");
                    CargarEscena(3);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule3"))
                {
                    CargarEscena(4);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule4"))
                {
                    CargarEscena(5);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule5"))
                {
                    CargarEscena(6);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule6"))
                {
                    CargarEscena(7);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule7"))
                {
                    CargarEscena(8);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule8"))
                {
                    CargarEscena(9);

                    DontDestroyOnLoad(interfaz);
                }
                else if (collision.CompareTag("Capsule9"))
                {
                    CargarEscena(10);

                    DontDestroyOnLoad(interfaz);
                }
            }
            else if (collision.CompareTag("Capsule"))
            {
                AyudaPasarNivel.SetActive(true);
            }
            else if (collision.CompareTag("Capsule2"))
            {
                AyudaPasarNivel.SetActive(true);
            }
            else if (collision.CompareTag("Capsule3"))
            {
                AyudaPasarNivel.SetActive(true);
            }
            else if (collision.CompareTag("Capsule4"))
            {
                AyudaPasarNivel.SetActive(true);
            }
            else if (collision.CompareTag("Capsule5"))
            {
                AyudaPasarNivel.SetActive(true);
            }
            else if (collision.CompareTag("Capsule6"))
            {
                AyudaPasarNivel.SetActive(true);
            }
            else if (collision.CompareTag("Capsule7"))
            {
                AyudaPasarNivel.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        AyudaPasarNivel.SetActive(false);
    }

    private void CargarEscena(int indiceEscena)
    {
        // Carga la escena con el índice proporcionado
        SceneManager.LoadScene(indiceEscena);

        // Registra el método CambiarPosicion para que se llame cuando se cargue la escena
    }
}
