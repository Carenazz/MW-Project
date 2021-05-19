using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EnemyHP : HealthSystem
{
    [SerializeField]
    private int setMax = 100;

    void Start()
    {
        SetHealth();
    }

    public void SetHealth()
    {
        maxHealth = setMax;
        currentHealth = maxHealth;
    }

    public override void Die()
    {
        base.Die();
        //anim.SetBool("Death", true);
        //this.m_coll.enabled = !this.m_coll.enabled;
        //this.rigid.gravityScale = 0;

        if (this.enabled == true)
        {
            this.enabled = false;
        }
    }
}
