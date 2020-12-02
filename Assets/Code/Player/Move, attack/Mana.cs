using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mana : MonoBehaviour
{
    #region Mana
    public int mana;
    private int maxMana = 150, manaRegen;
    private float regenTimer;
    public ManaBar manaBar;
    #endregion

    void Start()
    {
        mana = maxMana;
        manaRegen = 5;
    }

    void Update()
    {
        #region Mana regen
        regenTimer -= Time.deltaTime;
        if (regenTimer <= 0 && mana <= maxMana - manaRegen)
        {
            mana += manaRegen;
            regenTimer = 4f;
            manaBar.SetMana(mana);
        }
        #endregion
    }

    public void ManaUsed(int amount)
    {
        mana -= amount;
        manaBar.SetMana(mana);
    }

}
