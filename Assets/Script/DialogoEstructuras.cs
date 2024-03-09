using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoEstructuras : MonoBehaviour
{
    public bool Active;

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

    private float TypingTime = 0.05f;

    [SerializeField]
    public Movement MovimientoJugador;

    public Animator animacion;

    public GameObject AyudaPlayer;

    // Update is called once per frame



    void Start()
    {
        AyudaPlayer.SetActive(false);
        animacion = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (!Active)
            {
                StartDialog();
            }
            else if (Input.GetKeyDown(KeyCode.E) && dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogue();
            }
        }
    }

    public void StartDialog()
    {
        Canvas.SetActive(true);
        MovimientoJugador.Frente = true;
        dialoguePanel.SetActive(true);
        Active = true;
        lineIndex = 0;
        StartCoroutine(ShowLine());
        Time.timeScale = 0f;
        MovimientoJugador.movimientoBloqueado = true;
        AyudaPlayer.SetActive(false);
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
            yield return new WaitForSecondsRealtime(TypingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AyudaPlayer.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AyudaPlayer.SetActive(false);
            isPlayerInRange = false;
        }
    }

    IEnumerator EndDialog()
    {
        Active = false;
        dialoguePanel.SetActive(false);
        Canvas.SetActive(false);

        Time.timeScale = 1f;

        yield return new WaitForSeconds(0.4f);
        MovimientoJugador.movimientoBloqueado = false;
    }
}
