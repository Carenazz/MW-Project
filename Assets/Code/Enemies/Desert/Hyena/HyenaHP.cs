using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HyenaHP : HealthSystem
{
    [SerializeField]
    private int setmax = 200;

    void Start()
    {
        maxHealth = setmax;
        currentHealth = maxHealth;
    }
}

