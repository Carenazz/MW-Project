using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    #region Variables to be saved
    // Player related saving. (Experience, health, levels
    public int levels, health, expA;
    public float[] position;

    // Stats save
    public int str, stamina, will;
    public float agility;

    // Scene saved
    public int currentScene;
    #endregion

    public PlayerData (PlayerControls player)
    {
        // Levels, exp, health saved.
        levels = player.level;
        expA = player.expA;
        health = player.currentHealth;

        // Position save.
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

    // Stats saved.
    public PlayerData (Stats stats)
    {
        str = stats.Strength;
        stamina = stats.Stamina;
        will = stats.Will;
        agility = stats.Agility;
    }

    // Level saved.
    public PlayerData (LevelColl levels)
    {
        currentScene = levels.currentScene;
    }
}
