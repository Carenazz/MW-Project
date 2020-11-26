using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    PlayerControls player;
    public GameObject stats;
    private bool isOpen = false;

    private void Start()
    {
        player = GetComponent<PlayerControls>();
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
