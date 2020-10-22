using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    public GameObject level;
    public GameObject newCP;
    public GameObject cp;

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
