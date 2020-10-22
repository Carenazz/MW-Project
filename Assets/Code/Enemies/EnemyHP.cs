using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100, currentHealth;

    EnemyScript enemy;


    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<EnemyScript>();
    }

    void Update()
    {
        
    }


    #region Damage / Death
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
        animator.SetBool("Death", true);

        this.enabled = false;
        if (enemy.enabled == true)
        {
            enemy.enabled = false;
        }
    }
    #endregion
}
