using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{
    #region Variables
    public Animator animator;

    [SerializeField]
    private int currentHealth, maxHealth = 650;

    [SerializeField]
    Enabler enable;

    public GameObject key;

    Collider2D collm;
    BossScript enemy;
    #endregion

    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<BossScript>();
        enable = key.GetComponent<Enabler>();
        collm = GetComponent<Collider2D>();
    }

    #region Health System

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("Death", true);

        if (enemy.enabled == true)
        {
            enemy.enabled = false;
            enable.Enabled();
        }
        collm.enabled = !collm.enabled;
    }
    #endregion
}
