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
}
