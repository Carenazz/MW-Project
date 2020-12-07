using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField]
    private PlayerControls pXp;
    LevelSystem levelSystem;

    private void Awake()
    {
        pXp = FindObjectOfType<PlayerControls>();
    }

    // Below is planned work in progress.
    public void SetBar()
    {
        slider.maxValue = 100;
    }

    public void UpdateBar(int exp)
    {
        slider.value = exp;
    }

    private void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;
    }
}
