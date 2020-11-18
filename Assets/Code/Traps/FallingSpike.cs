using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private int damage = 50;

    PlayerControls hp;
    Rigidbody2D rb;
    Animator anim;
    public Transform target;
    public Transform rayT;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hp = GetComponent<PlayerControls>();
    }
    void Triggered()
    {
        rb.gravityScale = 4;
        anim.SetTrigger("Triggered");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayT.position, Vector2.left, 0.2f);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.transform.tag == "Player")
            {
                hp.TakeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Triggered();
        }
    }
}
