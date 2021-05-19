using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class VultureHP : HealthSystem
{
    [SerializeField]
    private int setMax = 200;

    void Start()
    {
        maxHealth = setMax;
        currentHealth = maxHealth;
        rigid = GetComponent<Rigidbody2D>();
    }
}
