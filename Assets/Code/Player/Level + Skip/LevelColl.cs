using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelColl : MonoBehaviour
{
    PlayerControls hp;
    
    private void Start()
    {
        hp = GetComponent<PlayerControls>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            transform.position = GameObject.FindWithTag("Spawner").transform.position;
            hp.Healed(20);
        }

        #region levelskips
        if (collision.transform.tag == "dSkip")
        {
            SceneManager.LoadScene(8);
            transform.position = GameObject.FindWithTag("Spawner").transform.position;
        }
        if (collision.transform.tag == "mSkip")
        {
            SceneManager.LoadScene(6);
        }
        if (collision.transform.tag == "SnowSkip")
        {
            SceneManager.LoadScene(7);
        }
        #endregion
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
