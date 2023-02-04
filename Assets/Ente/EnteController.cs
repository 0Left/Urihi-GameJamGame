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
    [SerializeField]private bulletBasicBehavior projectile;
    [SerializeField]private Transform launchOffset;
    [SerializeField]private bool hasTheSeed;
    [SerializeField]private int qtdBullets;
    
    public bool isCarryingTheSeed()
    {
        return hasTheSeed;
    }
    public void useTheSeed(){
        hasTheSeed = false;
    }
    public void recieveTheSeed(){
        hasTheSeed = true;
    }

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
        shoot();
    }
    private void FixedUpdate() {
        charRb.velocity = new Vector2(horizontal * speedMultiplyer, charRb.velocity.y);
    }
    private void flip(){
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            // Vector3 localScale = transform.localScale;
            // localScale.x *= -1f;
            // transform.localScale = localScale;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f,groundLayer);
    }
    private void shoot(){
        if(Input.GetKeyDown("z") && qtdBullets > 0)
        {
            qtdBullets--;
            Instantiate(projectile, launchOffset.position, transform.rotation);
        }
    }

}
