using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GnomosRecogidos : MonoBehaviour
{
    private float collected;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
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
