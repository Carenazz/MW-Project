﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingMove : MonoBehaviour
{
    #region Variables
    Rigidbody2D rb;

    [SerializeField]
    private float speed = 2f, dist = 12f;

    VikingHP hp;
    Transform player;
    private bool isFlipped = false;
    #endregion

    void Start()
    {
        hp = GetComponent<VikingHP>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    #region Follow & Look for Statemachine
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

    // Mål: Lave follow om så han ikke "teleporter" til dig og løber hurtigere i længere afstande.
    public void FollowPlayer()
    {
        if (!hp.dead)
        {
            if (Vector2.Distance(transform.position, player.position) < dist)
            {
                Vector2 velocity = new Vector2((transform.position.x - player.position.x) * speed, (transform.position.y - player.position.y) * speed);
                rb.velocity = -velocity;
            }
        }
    }
    #endregion
}
