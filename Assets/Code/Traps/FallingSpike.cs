using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private float timer = 5f;
    private int damage = 50;
    private bool triggered = false;

    Rigidbody2D rb;
    Animator anim;
    public Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (timer <= 0f)
        {
            this.enabled = false;
        }
    }

    void Triggered()
    {
        rb.gravityScale = 4;
        anim.SetTrigger("Triggered");
        timer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<PlayerControls>().TakeDamage(damage);
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
