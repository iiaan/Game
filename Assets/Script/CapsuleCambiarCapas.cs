using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCambiarCapas : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public int Capa = 2;

    void Update() { }

    public void OnTriggerEnter2D()
    {
        spriteRenderer.sortingOrder = Capa;
    }

    public void OnTriggerExit2D()
    {
        spriteRenderer.sortingOrder = 1;
    }
}
