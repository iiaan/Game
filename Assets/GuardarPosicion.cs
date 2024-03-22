using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPosicion : MonoBehaviour
{
    public Transform posicion;

    public bool UltimaPosicion = false;

    void Update()
    {
        if (UltimaPosicion == true)
        {
            SaveData();
        }
    }

    public void SaveData()
    {
        Vector2 posicionPersonaje = posicion.position;
        PlayerPrefs.SetFloat("PosX", posicionPersonaje.x);
        PlayerPrefs.SetFloat("PosY", posicionPersonaje.y);
    }
}
