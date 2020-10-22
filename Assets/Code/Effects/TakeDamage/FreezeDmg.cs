using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeDmg : MonoBehaviour
{
    public int damage = 5;
    public bool trigger = false;
    public float timer = 2f;

    private Transform player;
    PlayerControls playerHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerControls>();
    }

    private void Update()
    {
        if (trigger == true && timer <= 0f)
        {
            playerHealth.TakeDamage(damage);
            timer = 2f;
        }
        else if (trigger == true && timer > 0f)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            trigger = false;
        }
    }
}
