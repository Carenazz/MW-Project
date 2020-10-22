using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxPendulum : MonoBehaviour
{
    int damage = 50;
    public float distance = 1.5f;
    bool isUsed = false;

    public LayerMask whatIsPlayer;
    Animator animator;

    private Transform player;
    PlayerControls health;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = player.GetComponent<PlayerControls>();
    }

    private void Update()
    {
        Springs();
    }

    private void Springs()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsPlayer);

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

    public void Damage()
    {
        health.TakeDamage(damage);
    }
}
