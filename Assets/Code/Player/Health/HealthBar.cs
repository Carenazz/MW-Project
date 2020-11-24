using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerControls playerBar;

    private void Awake()
    {
        playerBar = FindObjectOfType<PlayerControls>();
    }
    public void SetMaxHealth(double health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth (double health)
    {
        slider.value = health;

    }
}
