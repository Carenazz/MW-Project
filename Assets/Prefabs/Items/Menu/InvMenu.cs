using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvMenu : MonoBehaviour
{
    public static bool isInvOpen = false;

    public GameObject UI_Inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isInvOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    void Open()
    {
        UI_Inventory.SetActive(true);
        isInvOpen = true;
    }

    void Close()
    {
        UI_Inventory.SetActive(false);
        isInvOpen = false;
    }
}
