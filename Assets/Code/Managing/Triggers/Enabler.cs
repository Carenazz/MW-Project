using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    #region Gameobjects
    public GameObject level;
    public GameObject newCP;
    public GameObject cp;
    public GameObject mover;
    #endregion

    public bool activated = false;

    public void Enabled()
    {
        level.SetActive(true);
    }

    public void CheckEnable()
    {
        newCP.SetActive(true);
    }

    public void CheckDisable()
    {
        cp.SetActive(false);
    }

    public bool Button()
    {
        if (!activated)
        {
            activated = true;
            return true;
        }
        else
        {
            activated = false;
            return false;
        }
    }
}
