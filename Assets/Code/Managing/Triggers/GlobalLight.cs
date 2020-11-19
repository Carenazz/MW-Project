using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLight : MonoBehaviour
{
    public GameObject gLight;
    public bool on = true;

    void Switcher()
    {
        if (on)
        {
            gLight.SetActive(false); 
            on = false;
        }
        else if (!on)
        {
            gLight.SetActive(true);
            on = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Switcher();
        }
    }
}
