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

    // Below is planned work in progress.
    public void SetBar()
    {
        slider.maxValue = levelSystem.experienceNextLvl;
    }

    public void UpdateBar(int exp)
    {
        slider.value = exp;
    }

    private void OnLvlChange(object sender, EventArgs e)
    {
        SetBar();
    }
}
