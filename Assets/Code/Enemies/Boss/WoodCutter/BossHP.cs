using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class BossHP : HealthSystem
{
    #region Variables
    private int setMax = 650;

    [SerializeField]
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

    // Find out how to get the key enabled once again.
    //void Update()
    //{
    //    if (isDead == true)
    //    {
    //        enable.Enabled();
    //    }
    //}
}
