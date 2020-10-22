using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    Animator anim;

    public LayerMask whatIsPlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(transform.position, Vector2.up, 0.5f, whatIsPlayer);

        if (Input.GetKeyDown(KeyCode.E) && playerInfo == GameObject.FindGameObjectWithTag("Player"))
        {
            Open();
        }
    }

    void Open()
    {
        anim.SetBool("Open", true);
    }

    void Loot()
    {
        
    }
}
