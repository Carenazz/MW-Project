using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLevel : MonoBehaviour
{
    Stats stats;
    LevelSystem level;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    void LevelStats()
    {
        stats.agility = (stats.agility * level) / 2;
        stats.str = (stats.str * level) / 2;
        stats.will = (stats.will / level) * 2;
        stats.stamina = stats.stamina + level;
    }

}
