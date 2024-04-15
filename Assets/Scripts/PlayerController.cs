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
    private bool hasActiveCreature = false;
    private bool airActive = false;
    public int availableSummons = 1;
    
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
        if (!hasActiveCreature && availableSummons > 0)
        {
            waterCreature.SetActive(true);
            hasActiveCreature = true;
            availableSummons--;
        }
        else if (hasActiveCreature && availableSummons == 0)
        {
            waterCreature.SetActive(false);
            hasActiveCreature = false;
            availableSummons++;
        }
    }

    private void summonAirCreature()
    {
        if (!hasActiveCreature && availableSummons > 0)
        {
            airCreature.SetActive(true);
            hasActiveCreature = true;
            airActive = true;
            availableSummons--;
        }
        else if (hasActiveCreature && availableSummons == 0)
        {
            airCreature.SetActive(false);
            hasActiveCreature = false;
            airActive = false;
            availableSummons++;
        }
    }
    private void summonIceCreature()
    {
        if (!hasActiveCreature && availableSummons > 0)
        {
            iceCreature.SetActive(true);
            hasActiveCreature = true;
            availableSummons--;
        }
        else if (hasActiveCreature && availableSummons == 0)
        {
            iceCreature.SetActive(false);
            hasActiveCreature = false;
            availableSummons++;
        }
    }
}
