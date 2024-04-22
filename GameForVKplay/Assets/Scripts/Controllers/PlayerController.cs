using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private float movementSpeed;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private DialogueManager dialogueManager;
    private bool isActive = true;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isActive)
        {
            direction = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        movementSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
        direction.Normalize();
        FlipPlayer();
        Animate();
        InteractionWithDialog();
    }

    private void FixedUpdate()
    {
        if (isActive)
            rigidbody.MovePosition(rigidbody.position + direction * speed * Time.fixedDeltaTime);
    }

    bool facingRight = true;
    void Flip()
    {
        facingRight = !facingRight;
        var scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void FlipPlayer()
    {
        if (facingRight == false && direction.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && direction.x < 0)
        {
            Flip();
        }
    }

    void Animate()
    {
        if (direction != Vector2.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        } 
        animator.SetFloat("Speed", movementSpeed);
    }

    private void InteractionWithDialog()
    {
        if (dialogueManager.IsDialogueActive())
        {
            isActive = false;
            animator.SetBool("IsDialogueActive", true);
            direction = Vector2.zero;
        }
        else if (direction != Vector2.zero)
        {
            animator.SetBool("IsDialogueActive", false);
        }
        else
        {
            isActive = true;
        }
    }
}
