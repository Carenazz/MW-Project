using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLevel : MonoBehaviour
{
    public int exp, level = 1, maxExp = 150;
    Stats stats;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        ExpHandler();
        LevelStats();
    }

    void ExpHandler()
    {

        if (maxExp <= exp)
        {
            level++;
            maxExp = level * maxExp;
            exp = 0;
        }
    }

    void LevelStats()
    {
        stats.agility = (stats.agility * level) / 2;
        stats.str = (stats.str * level) / 2;
        stats.will = (stats.will / level) * 2;
        stats.stamina = stats.stamina + level;
    }
}
