using System.Collections;
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
    public Slider slider;
    private Stats stats;

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }
    #endregion
    private void Update()
    {
        // Testing attempts
        if (Input.GetKey(KeyCode.L))
        {
            levelSystem.AddExperience(50);
        }
    }

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
