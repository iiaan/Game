using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionGnomo : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivarAnimacion(bool Recogida)
    {
        if (Recogida == true)
        {
            animator.SetBool("Recogida", true);
        }
    }
}
