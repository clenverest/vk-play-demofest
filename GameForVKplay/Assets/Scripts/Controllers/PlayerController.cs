using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 direction;
    float movementSpeed;
    Rigidbody2D rigidbody;
    Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        direction = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(direction.magnitude, 0.0f, 1.0f);
        direction.Normalize();
        FlipPlayer();
        Animate();
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.fixedDeltaTime); ;
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
}
