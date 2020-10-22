using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureHP : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    VultureMovement enemy;

    Rigidbody2D rigid;
    Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<VultureMovement>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

        animator.SetBool("Dead", true);

        this.enabled = false;

        if (enemy.enabled == true)
        {
            enemy.enabled = false;
            rigid.gravityScale = 4f;
        }
    }
}
