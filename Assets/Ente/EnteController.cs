using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteController : MonoBehaviour
{

    private Rigidbody2D charRb;
    [Range(0, 20)]
    public float speedMultiplyer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        charRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sideMoveDealer(speedMultiplyer);
        jumpDealer();
    }

    private void sideMoveDealer(float speed)
    {
        float scale = 2f;

        bool rightSide = (Input.GetKey(KeyCode.D) ?
            Input.GetKey(KeyCode.D) : Input.GetKey(KeyCode.RightArrow));

        bool leftSide = (Input.GetKey(KeyCode.A) ?
            Input.GetKey(KeyCode.A) : Input.GetKey(KeyCode.LeftArrow));

        if (rightSide && !leftSide)
        {
            charRb.velocity = new Vector2(1, 0) * speed;
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }

        if (leftSide && !rightSide)
        {
            charRb.velocity = new Vector2(-1, 0) * speed;
            gameObject.transform.localScale = new Vector3(-scale, scale, scale);
        }

        if (!rightSide && !leftSide)
        {
            charRb.velocity = new Vector2((charRb.velocity.x / 1.05f), charRb.velocity.y);
        }
    }
    public float jumpForce = 50;
    private void jumpDealer()
    {
        bool jump = Input.GetKey(KeyCode.Space);
        if (IsMeGrounded())
        {
            if (jump)
            {
                charRb.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
    private bool IsMeGrounded()
    {
        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
        float extraDistance = 0.02f;
        RaycastHit2D hit = Physics2D.Raycast(box.bounds.center, Vector2.down, box.bounds.extents.y + extraDistance);
        // Debug.DrawRay(box.bounds.center, Vector2.down * (box.bounds.extents.y + extraDistance));
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
        return hit.collider != null;
    }

}
