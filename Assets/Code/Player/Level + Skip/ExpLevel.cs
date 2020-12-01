using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLevel : MonoBehaviour
{
    Stats stats;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    void LevelStats()
    {
        stats.agility + 0.2f;
        stats.str + 1;
        stats.will + 1 / 3;
        stats.stamina + 1;
    }

}
