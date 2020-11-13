using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingHP : MonoBehaviour
{

    [SerializeField]
    private int currentHealth, maxHealth = 800, regen;
    public float regenTimer;
    public bool dead = false;

    #region Components
    Animator anim;
    VikingMove viking;
    Enabler enable;
    public GameObject key;
    Collider2D coll;
    #endregion

    void Start()
    {
        currentHealth = maxHealth;
        regenTimer = 5f;
        regen = 5;

        #region Get Components
        anim = GetComponent<Animator>();
        viking = GetComponent<VikingMove>();
        enable = key.GetComponent<Enabler>();
        coll = GetComponent<Collider2D>();
        #endregion
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            regenTimer  -= Time.deltaTime;
            if (regenTimer <= 0 && currentHealth <= 795)
            {
                Regenerate();
                regenTimer = 5f;
            }
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }

    #region Health system

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Regenerate()
    {
        currentHealth += regen;
    }

    void Die()
    {
        anim.SetBool("Death", true);
        dead = true;
        if (viking.enabled == true)
        {
            viking.enabled = false;
            enable.Enabled();
            coll.enabled = !coll.enabled;
        }
    }
    #endregion
}