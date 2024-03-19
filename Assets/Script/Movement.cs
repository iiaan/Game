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

    private float speed = 2f;

    private Vector2 moveInput;

    [Header("Sprint")]
    private float velocidadExtra = 4;

    private bool estaCorriendo = false;

    [SerializeField]
    private ParticleSystem particulas;

    private bool estaQuieto;

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
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!estaQuieto)
                {
                    estaCorriendo = true;
                    ReproducirParticulas();
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                DetenerParticulas();
                estaCorriendo = false;
            }

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                estaQuieto = false;
            }
            else
            {
                estaQuieto = true;
                if (!estaCorriendo)
                {
                    DetenerParticulas();
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (estaCorriendo == true && Input.GetKey(KeyCode.D))
                {
                    animator.SetBool("CorrerIzquierda", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Default", true);
                }
                else
                {
                    if (estaCorriendo == true && Input.GetKey(KeyCode.A))
                    {
                        animator.SetBool("CorrerIzquierda", true);
                        animator.SetBool("Left", false);
                        animator.SetBool("Default", false);
                    }
                    else
                    {
                        animator.SetBool("CorrerIzquierda", false);
                        animator.SetBool("Left", true);
                        animator.SetBool("Default", false);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("CorrerIzquierda", false);
                animator.SetBool("Left", false);
                animator.SetBool("Default", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (estaCorriendo == true && Input.GetKey(KeyCode.A))
                {
                    animator.SetBool("CorrerDerecha", false);
                    animator.SetBool("Right", false);
                    animator.SetBool("Default", true);
                }
                else
                {
                    if (estaCorriendo == true && Input.GetKey(KeyCode.D))
                    {
                        animator.SetBool("CorrerDerecha", true);
                        animator.SetBool("Right", false);
                        animator.SetBool("Default", false);
                    }
                    else
                    {
                        animator.SetBool("CorrerDerecha", false);
                        animator.SetBool("Right", true);
                        animator.SetBool("Default", false);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("Right", false);
                animator.SetBool("Default", true);
                animator.SetBool("CorrerDerecha", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (estaCorriendo == true && Input.GetKey(KeyCode.W))
                {
                    animator.SetBool("CorrerAbajo", false);
                    animator.SetBool("Down", false);
                    animator.SetBool("Default", true);
                }
                else
                {
                    if (estaCorriendo == true && Input.GetKey(KeyCode.S))
                    {
                        animator.SetBool("CorrerAbajo", true);
                        animator.SetBool("Down", false);
                        animator.SetBool("Default", false);
                    }
                    else
                    {
                        animator.SetBool("CorrerAbajo", false);
                        animator.SetBool("Down", true);
                        animator.SetBool("Default", false);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("CorrerAbajo", false);
                animator.SetBool("Down", false);
                animator.SetBool("Default", true);
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (estaCorriendo == true && Input.GetKey(KeyCode.S))
                {
                    animator.SetBool("Up", false);
                    animator.SetBool("Default", true);
                    animator.SetBool("CorrerArriba", false);
                }
                else
                {
                    if (estaCorriendo == true && Input.GetKey(KeyCode.W))
                    {
                        animator.SetBool("Up", false);
                        animator.SetBool("Default", false);
                        animator.SetBool("CorrerArriba", true);
                    }
                    else
                    {
                        animator.SetBool("CorrerArriba", false);
                        animator.SetBool("Up", true);
                        animator.SetBool("Default", false);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("CorrerArriba", false);
                animator.SetBool("Up", false);
                animator.SetBool("Default", true);
            }
        }
    }

    public void BloquearMovimiento(bool bloquear)
    {
        movimientoBloqueado = bloquear;
    }

    public void ReproducirParticulas()
    {
        if (!particulas.isPlaying)
            particulas.Play();
    }

    public void DetenerParticulas()
    {
        if (particulas.isPlaying)
            particulas.Stop();
    }

    private void FixedUpdate()
    {
        float currentSpeed = estaCorriendo ? velocidadExtra : speed;
        Rigidbody2D.velocity = new Vector2(Horizontal, Vertical);
        Rigidbody2D.MovePosition(
            Rigidbody2D.position + moveInput * currentSpeed * Time.fixedDeltaTime
        );
    }
}
