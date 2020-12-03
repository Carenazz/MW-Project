using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int str, stamina, will;
    public float agility;
    private LevelSystem levelSystem;

    private void Start()
    {
        str = 2;
        stamina = 1;
        will = 1;
        agility = 2f;
    }

    public void LevelStats(object sender, EventArgs e)
    {
        agility += 0.2f;
        str += 1;
        will += 1 / 3;
        stamina += 1;
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.onLevelChange += LevelStats;
    }
}
