using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class SmallTrap : MonoBehaviour
{
    int damage = 10;
    public float distance = 0.5f, timer = 0f;
    bool isUsed = false;

    public LayerMask whatIsPlayer;
    Animator animator;

    private Transform player;
    PlayerHealth health;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (timer <= 0)
        {
            Springs();
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0.5f)
            {
                animator.SetBool("Sprung", false);
                isUsed = false;
            }
        }
    }

    private void Springs()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsPlayer);

        if (hitinfo.collider != null && !isUsed)
        {
            isUsed = true;
            animator.SetBool("Sprung", true);
            timer = 2f;
        }
    }

    void Damage()
    {
        health.TakeDamage(damage);
    }
}
