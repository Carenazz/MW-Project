using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats : MonoBehaviour
{
    #region Stats, Text and levelSystem (including start)
    private int str = 2, stamina = 1, will = 1;
    public float agility = 2f;
    private LevelSystem levelSystem;
    [SerializeField]
    private Text strT, sta, willT, agiT;

    private void Start()
    {
        str = 2;
        stamina = 1;
        will = 1;
        agility = 2f;
        SetTexts();

        #region Level System
        LevelSystem levelSystem = new LevelSystem();
        #endregion
    }
    #endregion

    #region Stats levelling up and setting
    public void LevelStats(object sender, EventArgs e)
    {
        Agility += 0.2f;
        Strength += 1;
        Will += 1 / 3;
        Stamina += 1;
        SetTexts();
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.onLevelChange += LevelStats;
    }

    public void SetTexts()
    {
        strT.text = "Strength: " + str;
        sta.text = "Stamina: " + stamina;
        willT.text = "Will: " + will;
        agiT.text = "Agility: " + agility;
    }
    #endregion

    #region Saving and loading
    public void SaveStats()
    {
        SaveLoad.SaveStats(this);
    }

    public void LoadStats()
    {
        PlayerData data = SaveLoad.LoadStats();

        str = data.str + 2;
        stamina = data.stamina + 1;
        will = data.will + 1;
        agility = data.agility + 2f;

        SetTexts();
    }
    #endregion

    #region Properties
    public int Strength
    {
        get
        {
            return str;
        }
        set
        {
            str = value;
        }
    }

    public int Stamina
    {
        get
        {
            return stamina;
        }
        set
        {
            stamina = value;
        }
    }

    public int Will
    {
        get
        {
            return will;
        }
        set
        {
            will = value;
        }
    }

    public float Agility
    {
        get
        {
            return agility;
        }
        set
        {
            agility = value;
        }
    }
    #endregion
}
