using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    private bool Active;

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

    private float TypingTime = 0.05f;

    [SerializeField]
    public Movement MovimientoJugador;

    public bool AnimacionHecha;

    // Update is called once per frame

    void Start()
    {
        if (DialogManager.Instance == null)
        {
            animator = GetComponent<Animator>();
            MovimientoJugador.movimientoBloqueado = true;
            DialogManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isPlayerInRange == true)
        {
            if (!Active)
            {
                StartDialog();
            }
            else if (
                Input.GetKeyDown(KeyCode.Space)
                && dialogueText.text == dialogueLines[lineIndex]
            )
            {
                NextDialogue();
            }
        }
    }

    public void StartDialog()
    {
        dialoguePanel.SetActive(true);

        Active = true;

        lineIndex = 0;

        StartCoroutine(ShowLine());
    }

    private void NextDialogue()
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

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(TypingTime);
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
        GameObject princesa = GameObject.FindGameObjectWithTag("DialogoPrincesa");
        Active = false;
        animator.SetBool("PasarSiguiente", true);
        dialoguePanel.SetActive(false);
        Canvas.SetActive(false);
        yield return new WaitForSeconds(5f);

        MovimientoJugador.MirarDerecha = false;
        yield return new WaitForSeconds(1f);

        MovimientoJugador.movimientoBloqueado = false;

        princesa.SetActive(false);
    }
}
