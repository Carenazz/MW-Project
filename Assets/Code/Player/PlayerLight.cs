using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public GameObject playerLight;

    public void TurnOn()
    {
        playerLight.SetActive(true);
    }
    public void TurnOff()
    {
        playerLight.SetActive(false);
    }
}
