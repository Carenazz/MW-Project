using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public LevelWindow levelW;
    LevelSystem levelSystem;

    private void Awake()
    {
        levelW = GetComponent<LevelWindow>();
    }

    private void FixedUpdate()
    {
        SetBar();
    }
    
    // Below is planned work in progress.
    public void SetBar()
    {
        slider.maxValue = 100 * levelSystem.level;
    }

    public void UpdateBar(int exp)
    {
        slider.value = exp;
    }

    private void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.onLevelChange += Level_OnLvlChange;
    }

    private void Level_OnLvlChange(object sender, EventArgs e)
    {
        SetBar();
    }
}
