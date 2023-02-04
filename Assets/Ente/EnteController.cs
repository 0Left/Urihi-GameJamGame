using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteController : MonoBehaviour
{

    [Range(0, 20)]public float speedMultiplyer = 8f;
    private float horizontal;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    [SerializeField]private Rigidbody2D charRb;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            charRb.velocity = new Vector2(charRb.velocity.x, jumpingPower);
        }
        if(Input.GetButtonUp("Jump") && charRb.velocity.y > 0f)
        {
            charRb.velocity = new Vector2(charRb.velocity.x, charRb.velocity.y * 0.5f);
        }
        flip();
    }
    private void FixedUpdate() {
        charRb.velocity = new Vector2(horizontal * speedMultiplyer, charRb.velocity.y);
    }
    private void flip(){
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f,groundLayer);
    }
}
