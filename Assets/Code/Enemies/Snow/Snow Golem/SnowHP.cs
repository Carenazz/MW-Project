using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowHP : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 250, currentHealth;

    #region Components
    AIPath path;
    Seeker seek;
    Animator anim;
    Rigidbody2D rb;
    Collider2D m_coll;
    #endregion

    void Start()
    {
        currentHealth = maxHealth;

        #region Getting components
        anim = GetComponent<Animator>();
        path = GetComponent<AIPath>();
        seek = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        m_coll = GetComponent<Collider2D>();
        #endregion
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

    public void Die()
    {
        this.enabled = false;
        path.enabled = false;
        seek.enabled = false;
        anim.SetBool("Death", true);
        rb.gravityScale = 2;
        m_coll.enabled = !m_coll.enabled;
    }
}
