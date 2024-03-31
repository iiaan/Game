using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoManagerFinal : MonoBehaviour
{
    public static DialogoManagerFinal Instance;
    private bool Active = false;

    [SerializeField, TextArea(4, 6)]
    private string[] dialogueLines;

    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private GameObject Canvas;

    // Start is called before the first frame update

    private bool isPlayerInRange;

    private int lineIndex;

    private Animator animator;

    [SerializeField]
    private float TypingTime;

    [SerializeField]
    public Movement MovimientoJugador;

    public bool AnimacionHecha;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip voice;

    [SerializeField]
    private int AudioTyping;

    private bool dialogueStarted = false;

    [SerializeField]
    private GameObject princesa;

    [SerializeField]
    private GameObject Transicion;

    // Update is called once per frame

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = voice;
        if (DialogoManagerFinal.Instance == null)
        {
            animator = GetComponent<Animator>();
            MovimientoJugador.movimientoBloqueado = true;
            DialogoManagerFinal.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!Active && isPlayerInRange == true)
        {
            StartDialog();
        }
        else if (
            Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.E)
            || Input.GetMouseButtonDown(0) && dialogueText.text == dialogueLines[lineIndex]
        )
        {
            if (lineIndex < dialogueLines.Length - 1)
            {
                NextDialogue();
            }
            else
            {
                StartCoroutine(EndDialog());
            }
        }
    }

    public void StartDialog()
    {
        dialoguePanel.SetActive(true);

        if (!dialogueStarted)
        {
            lineIndex = 0;
            StartCoroutine(ShowLine());
            dialogueStarted = true;
        }

        Active = true;
    }

    public void NextDialogue()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            StartCoroutine(EndDialog());
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        int charIndex = 0;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;

            if (charIndex % AudioTyping == 0)
            {
                audioSource.PlayOneShot(voice);
            }

            charIndex++;

            yield return new WaitForSecondsRealtime(TypingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MovimientoJugador.MirarDerecha = true;
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    IEnumerator EndDialog()
    {
        Active = false;

        dialoguePanel.SetActive(false);
        Canvas.SetActive(false);
        audioSource.Stop();
        Transicion.SetActive(true);

        yield return new WaitForSecondsRealtime(4f);

        MovimientoJugador.MirarDerecha = true;
        yield return new WaitForSeconds(1f);

        MovimientoJugador.movimientoBloqueado = true;
    }
}
