using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ReproducirAnimacionUnaVez : MonoBehaviour
{
    public static ReproducirAnimacionUnaVez Instance;
    private Animator animator;
    private float Segundos = 3.3f;

    [SerializeField]
    private Movement movimiento;

    void Start()
    {
        if (ReproducirAnimacionUnaVez.Instance == null)
        {
            animator = GetComponent<Animator>();
            movimiento.movimientoBloqueado = true;
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
        movimiento.movimientoBloqueado = false;
        gameObject.SetActive(false);
    }
}
