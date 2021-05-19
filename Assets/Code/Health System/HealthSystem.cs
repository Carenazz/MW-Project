using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class HealthSystem : MonoBehaviour
{
    #region Variables to be declared in inherited scripts
    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected int regen = 0;
    public int currentHealth;
    [SerializeField]
    protected Animator anim;
    [SerializeField]
    protected Rigidbody2D rigid;
    [SerializeField]
    protected Collider2D m_coll;
    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
        m_coll = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Healed(int heal)
    {
        currentHealth += heal;
    }

    #region Damage / Death
    // Take damage - Unified for all.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Basic death setup.
    public virtual void Die()
    {
        anim.SetBool("Death", true);

        this.m_coll.enabled = !this.m_coll.enabled;
        this.rigid.gravityScale = 0;
    }
    #endregion
}
