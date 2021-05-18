using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HealthSystem : AbstractHP
{
    #region Damage / Death
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetBool("Death", true);

        this.enabled = false;
        if (this.enabled == true)
        {
            this.enabled = false;
        }
        this.m_coll.enabled = !this.m_coll.enabled;
        this.rigid.gravityScale = 0;
    }
    #endregion
}
