using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ReproducirAnimacionUnaVez : MonoBehaviour
{
    public static ReproducirAnimacionUnaVez Instance;
    private Animator animator;
    private float Segundos = 3.9f;

    void Start()
    {
        if (ReproducirAnimacionUnaVez.Instance == null)
        {
            animator = GetComponent<Animator>();

            StartCoroutine(ReproducirYDestruir());
            ReproducirAnimacionUnaVez.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ReproducirYDestruir()
    {
        // Reproduce la animación
        animator.Play("TransicionEscena");

        yield return new WaitForSeconds(Segundos);

        gameObject.SetActive(false);
    }
}
