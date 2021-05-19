using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerHealth : HealthSystem
{
    public HealthBar healthBar;
    Stats stats;
    Weapon weapon;

    private float deathTimer = 1.5f, regenTimer = 10f;

    [SerializeField]
    private int setMax = 100;

    private void Start()
    {
        maxHealth = setMax;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        stats = GetComponent<Stats>();
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (regenTimer <= 0f)
        {
            Regeneration();
        }
        else
        {
            healthBar.SetHealth(currentHealth);
            regenTimer -= Time.deltaTime;
        }
        if (currentHealth > maxHealth + stats.Stamina * 10)
        {
            currentHealth = maxHealth + stats.Stamina * 10;
        }
    }

    private void Regeneration()
    {
        currentHealth += 5 * stats.Will;
        healthBar.SetHealth(currentHealth);
        regenTimer = 10f;
    }

    public override void Die()
    {
        anim.SetBool("Death", true);
        weapon.enabled = false;
        if (deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
            m_coll.enabled = !m_coll.enabled;
        }
        else if (deathTimer <= 0)
        {
            anim.SetBool("Death", false);
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            deathTimer = 1.5f;
            transform.position = GameObject.FindWithTag("Respawn").transform.position;
            weapon.enabled = true;
            m_coll.enabled = true;
        }
    }
}
