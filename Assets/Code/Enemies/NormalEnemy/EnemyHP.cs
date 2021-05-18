using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator animator;

    private double maxHealth = 100, currentHealth;

    #region Components
    Rigidbody2D rigid;
    Collider2D m_coll;
    EnemyScript enemy;
    #endregion

    void Start()
    {

        currentHealth = maxHealth;

        #region calling components
        enemy = GetComponent<EnemyScript>();
        m_coll = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
        #endregion
    }

    #region Damage / Death
    public void TakeDamage(int damage)
    {
        Health -= damage;

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
        m_coll.enabled = !m_coll.enabled;
        rigid.gravityScale = 0;
    }
    #endregion

    public double Health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }
}
