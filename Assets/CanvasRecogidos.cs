using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRecogidos : MonoBehaviour
{
    public static CanvasRecogidos Instance;

    private void Awake()
    {
        if (CanvasRecogidos.Instance == null)
        {
            CanvasRecogidos.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
