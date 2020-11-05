using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    PlayerControls player;

    private void Awake()
    {
        player = GetComponent<PlayerControls>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == player)
        {
            this.transform.parent = collision.gameObject.transform;
        }
    }
}
