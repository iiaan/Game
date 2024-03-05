using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private bool Active = true;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Active && Input.GetKeyDown(KeyCode.Space)) { }
    }

    public void StartDialog()
    {
        Active = true;
        Time.timeScale = 0f;
    }

    public void EndDialog()
    {
        Active = false;
        Time.timeScale = 1f;
    }
}
