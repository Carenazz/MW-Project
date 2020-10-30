using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public int mana;
    private int maxMana = 150, manaRegen;
    private float regenTimer;

    public ManaBar manaBar;

    void Start()
    {
        mana = maxMana;
        manaRegen = 5;
    }

    void Update()
    {
        regenTimer -= Time.deltaTime;
        if (regenTimer <= 0 && mana <= 145)
        {
            mana += manaRegen;
            regenTimer = 4f;
            manaBar.SetMana(mana);
        }
    }

    public void ManaUsed(int amount)
    {
        mana -= amount;
        manaBar.SetMana(mana);
    }

}
