using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public double posicion = -1;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        {
            GameObject interfaz = GameObject.FindGameObjectWithTag("NumeroGnomos");

            if (collision.collider.CompareTag("Capsule"))
            {
                CargarEscena(2);

                DontDestroyOnLoad(interfaz);
            }
        }
    }

    private void CargarEscena(int indiceEscena)
    {
        // Carga la escena con el índice proporcionado
        SceneManager.LoadScene(indiceEscena);

        // Registra el método CambiarPosicion para que se llame cuando se cargue la escena
    }
}
