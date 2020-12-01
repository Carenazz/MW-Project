using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    // Inspired by CodeMonkey

    private int level, experience, experienceNextLvl;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
        experienceNextLvl = 100;
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        if (experience >= experienceNextLvl)
        {
            level++;
            experience -= experienceNextLvl;
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }
}
