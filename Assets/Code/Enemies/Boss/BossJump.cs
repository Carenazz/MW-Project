using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJump : MonoBehaviour
{
    public float jumpSpeed = 8f;
    public float distance = 0.5f;
    
    public bool isJumping = false;

    public Animator anim;
    public LayerMask whatIsPlatform;
    public Transform target;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(target.position, Vector2.up, distance, whatIsPlatform);
        Debug.DrawRay(target.position, Vector2.up, Color.red);
        if (hitInfo.collider != null)
        {
            if (!isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                isJumping = true;
                anim.SetBool("Jump", true);
            }
            else
            {
                isJumping = false;
                anim.SetBool("Jump", false);
            }
        }
    }
}
