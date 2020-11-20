using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLight : MonoBehaviour
{
    public GameObject gLight;
    public bool on = true;
    private float timer = 0.5f;

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    void Switcher()
    {
        if (on)
        {
            gLight.SetActive(false); 
            on = false;
            timer = 0.5f;
        }
        else if (!on)
        {
            gLight.SetActive(true);
            on = true;
            timer = 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && timer <= 0f)
        {
            Switcher();
        }
    }
}
