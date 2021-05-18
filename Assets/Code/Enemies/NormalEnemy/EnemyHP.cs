using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnemyHP : HealthSystem
{
    [SerializeField]
    private double setMax = 100;

    #region Components
    EnemyScript enemy;
    #endregion

    void Start()
    {
        #region calling components
        enemy = GetComponent<EnemyScript>();
        #endregion

        SetHealth();
    }

    public void SetHealth()
    {
        maxHealth = setMax;

        currentHealth = maxHealth;
    }

    //#region Damage / Death
    //public void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;

    //    animator.SetTrigger("Hurt");

    //    if (currentHealth <= 0)
    //    {
    //        Die();
    //    }
    //}

    //public void Die()
    //{
    //    animator.SetBool("Death", true);

    //    this.enabled = false;
    //    if (enemy.enabled == true)
    //    {
    //        enemy.enabled = false;
    //    }
    //    m_coll.enabled = !m_coll.enabled;
    //    rigid.gravityScale = 0;
    //}
    //#endregion
}
