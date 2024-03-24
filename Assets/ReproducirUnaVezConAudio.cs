using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ReproducirUnaVezConAudio : MonoBehaviour
{
    public static ReproducirUnaVezConAudio Instance;
    private Animator animator;
    private float Segundos = 3.4f;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip voice;

    [SerializeField]
    public DialogoAbrirCofre Activar;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = voice;
        Activar.Active = true;
        if (ReproducirUnaVezConAudio.Instance == null)
        {
            animator = GetComponent<Animator>();

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
        gameObject.SetActive(false);

        Activar.Active = false;
    }
}
