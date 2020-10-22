using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowHP : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 250, currentHealth;

    AIPath path;
    Seeker seek;
    Animator anim;


    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        path = GetComponent<AIPath>();
        seek = GetComponent<Seeker>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            this.enabled = false;
            path.enabled = false;
            seek.enabled = false;
            anim.SetBool("Death", true);
            
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }
}
