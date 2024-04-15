using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject waterCreature;

    public GameOverScreen gameOverScreen;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float jumpPower = 16f;
    private bool isFacingRight = true;
    private bool hasActiveCreature = false;
    
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            summonCreature();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "Hazards")
        //{
        //    GameOver();
        //    gameObject.SetActive(false);
        //}
    }

    private void summonCreature()
    {
        if (!hasActiveCreature)
        {
            waterCreature.SetActive(true);
            hasActiveCreature = true;
        }
        else if (hasActiveCreature)
        {
            waterCreature.SetActive(false);
            hasActiveCreature = false;
        }
    }
}
