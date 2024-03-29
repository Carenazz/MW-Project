﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 9f, timer = 3f;
    public int damage = 20;
    public Rigidbody2D rigid;
    public GameObject impactEffect;

    void Start()
    {
        rigid.velocity = transform.right * speed;    
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        HealthSystem enemy = hitInfo.GetComponent<HealthSystem>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(this);
    }
}
