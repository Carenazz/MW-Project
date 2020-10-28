using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{

    private int mana, maxMana = 150, manaRegen;
    private float regenTimer;

    void Start()
    {
        mana = maxMana;
        manaRegen = 5;
    }

    void Update()
    {
        regenTimer -= Time.deltaTime;

        if (regenTimer <= 0)
        {
            mana += manaRegen;
            regenTimer = 4f;
        }
    }

    void ManaUsed(int amount)
    {
        mana -= amount;
    }

}
