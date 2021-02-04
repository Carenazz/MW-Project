using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigHP : MonoBehaviour
{
    #region Variables
    public Animator anim;

    [SerializeField]
    private int maxHealth = 100;
    public int currentHealth;

    BrigMove move;
    #endregion

    void Start()
    {
        currentHealth = maxHealth;
        move = GetComponent<BrigMove>();
    }

    #region Health System
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetBool("Dead", true);

        this.enabled = false;
        move.enabled = false;
    }
    #endregion
}
