using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    public bool Left;
    public bool Right;
    public bool Default;
    private float Horizontal;
    private float Vertical;

    public bool movimientoBloqueado;

    public bool MirarDerecha = false;

    [SerializeField]
    public DialogoEstructuras DialogoOn;

    public bool movimientoDialogo;
    public bool Frente = false;

    [SerializeField]
    private float speed = 3f;

    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Frente == true)
        {
            Horizontal = 0.0f;
            Vertical = 0.0f;
            animator.SetBool("Default", Frente);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        animator.SetBool("MirarDerecha", MirarDerecha);

        if (!movimientoBloqueado)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(Horizontal, Vertical).normalized;

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Left", true);
                animator.SetBool("Default", false);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("Left", false);
                animator.SetBool("Default", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Right", true);
                animator.SetBool("Default", false);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("Right", false);
                animator.SetBool("Default", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Down", true);
                animator.SetBool("Default", false);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("Down", false);
                animator.SetBool("Default", true);
            }
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("Up", true);
                animator.SetBool("Default", false);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("Up", false);
                animator.SetBool("Default", true);
            }
        }
    }

    public void BloquearMovimiento(bool bloquear)
    {
        movimientoBloqueado = bloquear;
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Vertical);
        Rigidbody2D.MovePosition(Rigidbody2D.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
