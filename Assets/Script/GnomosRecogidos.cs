using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GnomosRecogidos : MonoBehaviour
{
    public static GnomosRecogidos Instace;
    private float collected;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        if (GnomosRecogidos.Instace == null)
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            GnomosRecogidos.Instace = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
