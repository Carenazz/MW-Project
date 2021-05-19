using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class BossHP : HealthSystem
{
    #region Variables
    [SerializeField]
    private int setMax = 650;

    Enabler enable;
    public GameObject key;
    BossScript enemy;
    #endregion

    void Start()
    {
        maxHealth = setMax;
        currentHealth = maxHealth;
        enemy = GetComponent<BossScript>();
        enable = key.GetComponent<Enabler>();
    }

    public override void Die()
    {
        base.Die();

        enable.Enabled();
    }
}
