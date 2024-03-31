using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GnomosRecogidos : MonoBehaviour
{
    public static GnomosRecogidos Instance;
    private float collected;

    private TextMeshProUGUI textMesh;

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
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = collected.ToString("0");
    }

    public void SumarGnomos(float SumarGnomos)
    {
        collected += SumarGnomos;
    }
}
