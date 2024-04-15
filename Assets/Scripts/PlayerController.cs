using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject waterCreature;
    public GameObject airCreature;
    public GameObject iceCreature;

    public GameOverScreen gameOverScreen;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float jumpPower = 16f;
    private bool isFacingRight = true;

    private bool waterActive = false;
    private bool airActive = false;
    private bool iceActive = false;
    
    
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
            summonWaterCreature();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            summonAirCreature();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            summonIceCreature();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (airActive)
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
        //gameOverScreen.Setup();
    }

    private void summonWaterCreature()
    {
        if (!waterActive && !airActive && !iceActive)
        {
            waterCreature.SetActive(true);
            waterActive = true;
        }
        else if (waterActive && !airActive && !iceActive)
        {
            waterCreature.SetActive(false);
            waterActive = false;
        }
    }

    private void summonAirCreature()
    {
        if (!waterActive && !airActive && !iceActive)
        {
            airCreature.SetActive(true);
            airActive = true;
        }
        else if (!waterActive && airActive && !iceActive)
        {
            airCreature.SetActive(false);
            airActive = false;
        }
    }
    private void summonIceCreature()
    {
        if (!waterActive && !airActive && !iceActive)
        {
            iceCreature.SetActive(true);
            iceActive = true;
        }
        else if (!waterActive && !airActive && iceActive)
        {
            iceCreature.SetActive(false);
            iceActive = false;

        }
    }
}
