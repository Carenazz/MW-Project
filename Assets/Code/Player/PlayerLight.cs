using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public GameObject playerLight;
    private bool ena = false;
    private float timer = 0f;

    private void Update()
    {
        timer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "LightsTrigger")
        {
            if (!ena && timer <= 0f)
            {
                TurnOn();
                ena = true;
                timer = 5f;
            }
            else if (ena && timer <= 0f)
            {
                TurnOff();
                ena = false;
                timer = 5f;
            }
        }
    }
    public void TurnOn()
    {
        playerLight.SetActive(true);
    }
    public void TurnOff()
    {
        playerLight.SetActive(false);
    }
}
