using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ReproducirUnaVezConAudio : MonoBehaviour
{
    public static ReproducirUnaVezConAudio Instance;
    private Animator animator;
    private float Segundos = 3.4f;

    [SerializeField]
    private Movement movimiento;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip voice;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = voice;

        if (ReproducirUnaVezConAudio.Instance == null)
        {
            animator = GetComponent<Animator>();
            movimiento.movimientoBloqueado = true;
            StartCoroutine(ReproducirYDestruir());
            ReproducirUnaVezConAudio.Instance = this;
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
        audioSource.PlayOneShot(voice);
        yield return new WaitForSeconds(Segundos);
        movimiento.movimientoBloqueado = false;
        gameObject.SetActive(false);
    }
}
