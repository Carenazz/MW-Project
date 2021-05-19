using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    int damage = 25;
    public float distance = 0.5f;
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
        Springs();
    }

    private void Springs()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsPlayer);

        if (hitinfo.collider != null && !isUsed)
        {
            isUsed = true;
            animator.SetBool("Sprung", true);
        }
        else if (isUsed == true)
        {
            this.enabled = false;
        }
    }

    private void Damage()
    {
        health.TakeDamage(damage);
    }
}
