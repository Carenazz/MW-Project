using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HyenaHP : HealthSystem
{
    #region Variables
    public Animator animator;

    [SerializeField]
    private int setmax = 200;

    Movement enemy;
    #endregion

    void Start()
    {
        maxHealth = setmax;
        currentHealth = maxHealth;
        enemy = GetComponent<Movement>();
    }
}

