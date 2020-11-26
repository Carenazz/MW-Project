using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLight : MonoBehaviour
{
    public GameObject gLight;
    public GameObject lSwitch;
    public bool switched = false;

    void Switcher()
    {
        if (!switched)
        {
            gLight.SetActive(false);
            lSwitch.SetActive(false);
            switched = true;
        }
        else if (switched)
        {
            gLight.SetActive(true);
            lSwitch.SetActive(false);
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
