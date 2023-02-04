using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteLadderMov : MonoBehaviour
{
    private float vertical;
    private float velocity = 8f;
    private bool isLadder;
    private bool isClimbing;
    [SerializeField] private Rigidbody2D charRb;
    private float gravityScale;
    // Update is called once per frame
    private void Start() {
        gravityScale = charRb.gravityScale;
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical)>0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate() 
    {
        if(isClimbing)
        {
            charRb.gravityScale = 0;
            charRb.velocity = new Vector2(charRb.velocity.x,vertical * velocity);
        }
        else
        {
            charRb.gravityScale = gravityScale;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
