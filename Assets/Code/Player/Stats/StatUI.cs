using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    public GameObject stats;
    private bool isOpen = false;
    Stats player;

    private void Start()
    {
        player = stats.GetComponent<Stats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowStats();
        }
    }

    void ShowStats()
    {
        if (!isOpen)
        {
            stats.SetActive(true);
            isOpen = true;
        }
        else
        {
            stats.SetActive(false);
            isOpen = false;
        }
    }
}
