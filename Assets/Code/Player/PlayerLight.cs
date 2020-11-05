using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public PlayerControls player;


    void Start()
    {
        player = FindObjectOfType<PlayerControls>();    
    }

    void FixedUpdate()
    {

    }
}
