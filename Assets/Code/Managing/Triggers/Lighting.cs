using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public bool ena = false;
    PlayerLight turn;
    public GameObject lights;

    private void Start()
    {
        turn = lights.GetComponent<PlayerLight>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (!ena)
            {
                turn.TurnOn();
                ena = true;
            }
            else if (ena)
            {
                turn.TurnOff();
                ena = false;
            }
        }
    }
}
