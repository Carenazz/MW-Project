using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    LevelColl scenes;
    Stats stats;

    private void Awake()
    {
        scenes = GetComponent<LevelColl>();
        stats = GetComponent<Stats>();
    }

    #region finished menu settings
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    public void Settings()
    {
        GetComponent<SettingsMenu>();
    }

    public void LoadGame()
    {
        scenes.LoadLevel();

        PlayerData data = SaveLoad.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        stats.LoadStats();
    }
}
