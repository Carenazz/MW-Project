using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    // Inspired by CodeMonkey
    public event EventHandler onExpChange, onLevelChange;
    public int level, experience, experienceNextLvl;

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
            if (onLevelChange != null) onLevelChange(this, EventArgs.Empty);
        }
        if (onExpChange != null) onLevelChange(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        return (float)experience / experienceNextLvl;
    }
}
