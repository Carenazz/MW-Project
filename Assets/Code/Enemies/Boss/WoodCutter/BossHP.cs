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

    BossScript enemy;
    #endregion

    void Start()
    {
        currentHealth = maxHealth;
        enemy = GetComponent<BossScript>();
        enable = key.GetComponent<Enabler>();

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
    }
    #endregion
}
