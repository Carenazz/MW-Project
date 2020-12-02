using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Image experienceBarImage;
    private LevelSystem levelSystem;

    private void Update()
    {
        // Testing attempts
        Input.GetKey(KeyCode.L);
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "Level\n" + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

        levelSystem.onExpChange += LevelSystem_OnExpChanged;
        levelSystem.onLevelChange += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
    }

    private void LevelSystem_OnExpChanged(object sender, System.EventArgs e)
    {
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }
}
