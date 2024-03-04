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
            GameObject personaje = GameObject.FindGameObjectWithTag("Player");
            GameObject interfaz = GameObject.FindGameObjectWithTag("NumeroGnomos");

            if (collision.collider.CompareTag("Capsule"))
            {
                CargarEscena(2);

                DontDestroyOnLoad(personaje);
            }
            else if (collision.collider.CompareTag("Capsule2"))
            {
                CargarEscena(1);
                Destroy(personaje);
            }

            SceneManager.sceneLoaded += CambiarPosicion;
        }
    }

    private void CargarEscena(int indiceEscena)
    {
        // Carga la escena con el índice proporcionado
        SceneManager.LoadScene(indiceEscena);

        // Registra el método CambiarPosicion para que se llame cuando se cargue la escena
        SceneManager.sceneLoaded += CambiarPosicion;
    }

    private void CambiarPosicion(Scene scene, LoadSceneMode mode)
    {
        // Verifica si la escena cargada es la correcta y mueve el personaje a la posición deseada
        if (scene.buildIndex == 1)
        {
            // Mueve el personaje a la posición deseada en la escena 1
            transform.position = new Vector2(-11f, 0);
        }
        else if (scene.buildIndex == 0)
        {
            // Mueve el personaje a la posición deseada en la escena 0
            transform.position = new Vector2(9f, -1);
        }

        // Desregistra el método CambiarPosicion cuando se desactive el objeto
        SceneManager.sceneLoaded -= CambiarPosicion;
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
