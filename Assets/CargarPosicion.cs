using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPosicion : MonoBehaviour
{
    public Transform personajeTransform;

    void Start()
    {
        float posX = PlayerPrefs.GetFloat("PosX");
        float posY = PlayerPrefs.GetFloat("PosY");

        Vector2 nuevaPosicion = new Vector2(posX, posY);
        Debug.Log(nuevaPosicion);
        personajeTransform.position = nuevaPosicion;
    }
}
