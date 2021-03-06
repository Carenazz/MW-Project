﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    #region Declarations
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Image experienceBarImage;
    private LevelSystem levelSystem;
    private PlayerControls player;
    private Stats stats;
    public XPBar xp;

    private void Awake()
    {
        stats = GetComponent<Stats>();
        xp = GetComponent<XPBar>();
        player = GetComponent<PlayerControls>();
    }
    #endregion


    #region Setting system
    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "Level: " + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

        levelSystem.onExpChange += LevelSystem_OnExpChanged;
        levelSystem.onLevelChange += LevelSystem_OnLevelChanged;
    }
    #endregion

    #region Events and system
    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
    }

    private void LevelSystem_OnExpChanged(object sender, System.EventArgs e)
    {
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }
    #endregion
}
