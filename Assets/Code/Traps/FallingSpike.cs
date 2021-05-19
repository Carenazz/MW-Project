using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private int damage = 50;

    PlayerHealth hp;
    Rigidbody2D rb;
    Animator anim;
    public Transform target;
    public Transform rayT;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hp = player.GetComponent<PlayerHealth>();
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
            if (hitInfo == GameObject.FindGameObjectWithTag("Player"))
            {
                hp.TakeDamage(damage);
            }
            if (hitInfo.transform.CompareTag("Platform"))
            {
                Destroy(this);
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
