using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyenaHP : MonoBehaviour
{
    #region Variables
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    Movement enemy;
    #endregion

    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<Movement>();
    }

    #region Health System
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
        }
    }
    #endregion
}

