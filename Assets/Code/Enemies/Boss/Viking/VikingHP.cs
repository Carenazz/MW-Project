using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class VikingHP : HealthSystem
{

    [SerializeField]
    private int setMax = 800;
    public float regenTimer;
    public bool dead = false;

    #region Components
    VikingMove viking;
    Enabler enable;
    public GameObject key;
    #endregion

    void Start()
    {
        maxHealth = setMax;
        currentHealth = maxHealth;
        regenTimer = 5f;
        regen = 5;

        #region Get Components
        anim = GetComponent<Animator>();
        viking = GetComponent<VikingMove>();
        enable = key.GetComponent<Enabler>();
        #endregion
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            regenTimer  -= Time.deltaTime;
            if (regenTimer <= 0 && currentHealth <= (maxHealth - 5))
            {
                regenTimer = 5f;
            }
        }
    }
}