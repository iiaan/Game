using System.Collections;
using UnityEngine;

public class ReproducirAnimacionUnaVez : MonoBehaviour
{
    private Animator animator;
    private float Segundos = 3.9f;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ReproducirYDestruir());
    }

    IEnumerator ReproducirYDestruir()
    {
        // Reproduce la animación
        animator.Play("TransicionEscena");

        yield return new WaitForSeconds(Segundos);

        gameObject.SetActive(false);
    }
}
