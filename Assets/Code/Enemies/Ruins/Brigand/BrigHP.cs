using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BrigHP : HealthSystem
{
    #region Variables
    private int setMax = 250;
    BrigMove move;
    #endregion

    void Start()
    {
        maxHealth = setMax;
        currentHealth = maxHealth;
        move = GetComponent<BrigMove>();
    }
}
