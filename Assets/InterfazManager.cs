using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazManager : MonoBehaviour
{
    public GameObject interfaz;

    // Se llama cuando el script se activa por primera vez
    void Awake()
    {
        // Desactivar la interfaz al principio de la escena
        interfaz.SetActive(false);
    }

    // Método para activar la interfaz
    public void ActivarInterfaz()
    {
        // Activar la interfaz
        interfaz.SetActive(true);
    }
}
