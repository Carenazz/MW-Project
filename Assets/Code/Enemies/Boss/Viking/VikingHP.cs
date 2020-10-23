using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingHP : MonoBehaviour
{
    int currentHealth, maxHealth = 500, regen;
    public float regenTimer;

    void Start()
    {
        currentHealth = maxHealth;
        regenTimer = 5f;
        regen = 5;
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            regenTimer  -= Time.deltaTime;
            if (regenTimer <= 0)
            {
                Regenerate();
                regenTimer = 5f;
            }
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

    public void Regenerate()
    {
        currentHealth += regen;
    }

    void Die()
    {
        this.enabled = false;
    }
}
