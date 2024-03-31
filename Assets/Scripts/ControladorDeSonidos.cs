using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonidos : MonoBehaviour
{
    public static ControladorDeSonidos Instance;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Update()
    {
        if (Time.timeScale == 0)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.UnPause();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
