using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAnimacion : MonoBehaviour
{
    public DialogoAbrirCofre Transicion;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Transicion.ActivarAnimacionPasarEscena == true)
        {
            animator.SetBool("AnimacionDeCofre", true);
        }
    }
}
