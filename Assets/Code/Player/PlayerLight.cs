using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    private bool ena = false;
    public Transform playerLight;
    Lighting enabler;


    private void Start()
    {
        enabler = GetComponent<Lighting>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == enabler)
        {
            if (!ena)
            {
                TurnOn();
            }
            else if (ena)
            {
                TurnOff();
            }
        }
    }

    private void TurnOn()
    {
        
    }
    private void TurnOff()
    {

    }
}
