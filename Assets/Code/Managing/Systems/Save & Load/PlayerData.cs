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

    #endregion

    public PlayerData (PlayerControls player)
    {
        levels = player.level;
        expA = player.expA;
        health = player.currentHealth;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

    public PlayerData (Stats stats)
    {
        str = stats.str;
        stamina = stats.stamina;
        will = stats.will;
        agility = stats.agility;
    }
}
