using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    #region Gameobjects
    public GameObject level;
    public GameObject newCP;
    public GameObject cp;
    #endregion

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
}
