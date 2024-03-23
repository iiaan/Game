using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogoAbrirCofre : MonoBehaviour
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



    private int lineIndex;

    private float TypingTime = 0.05f;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip voice;

    [SerializeField]
    private int AudioTyping;

    private bool dialogueStarted = false;

    public GameObject personajePrincipal;

    public bool ActivarAnimacionPasarEscena = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = voice;
    }

    void Update()
    {
        if (!Active)
        {
            StartDialog();
        }
        else if (
            Input.GetKeyDown(KeyCode.E)
            || Input.GetMouseButtonDown(0)
            || Input.GetKeyDown(KeyCode.Space) && dialogueText.text == dialogueLines[lineIndex]
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

    IEnumerator EndDialog()
    {
        Active = false;
        dialoguePanel.SetActive(false);
        Canvas.SetActive(false);
        ActivarAnimacionPasarEscena = true;

        yield return new WaitForSeconds(2f);

        gameObject.SetActive(true);
        SceneManager.LoadScene(9);
    }
}
