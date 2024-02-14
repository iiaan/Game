using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    public bool Left;
    public bool Right;
    public bool Default;
    private float Horizontal;
    private float Vertical;

    public bool changeLevelCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Left", true);
            animator.SetBool("Default", false);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Left", false);
            animator.SetBool("Default", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Right", true);
            animator.SetBool("Default", false);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
            animator.SetBool("Default", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Down", true);
            animator.SetBool("Default", false);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Down", false);
            animator.SetBool("Default", true);
        }
        if (Input.GetKeyDown(KeyCode.W))
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

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Vertical);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Capsule"))
        {
            changeLevelCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Capsule"))
        {
            changeLevelCollider = false;
        }
    }
}
