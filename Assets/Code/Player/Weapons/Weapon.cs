using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region variables

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;


    // Normal attack
    public float attackRange = 0.5f;
    public int attackDamage = 20;

    // Strong attack
    public float sAttRange = 0.75f;
    public int sDamage = 50;

    // Attack Timers
    public float attackRate = 1.5f;
    float nextAttack = 0f;
    
    Stats stats;
    #endregion


    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetButtonDown("Light Attack"))
            {
                animator.SetTrigger("Attacking");

                nextAttack = Time.time + 1.5f / attackRate / (stats.Agility / 3);
            }
            if (Input.GetButtonDown("Strong Attack"))
            {
                animator.SetTrigger("StrAtt");

                nextAttack = Time.time + 3f / attackRate / (stats.Agility / 3);
            }
        }

    }

    #region light attack
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D hit in hitEnemies)
        {
            if (hit.tag == "Enemy")
            {
                if (hit.gameObject.GetComponent<HealthSystem>() != null)
                {
                    hit.GetComponent<HealthSystem>().TakeDamage(attackDamage + stats.Strength);
                }
            }
        }
    }

    #endregion

    #region strong attack

    void Attack2()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, sAttRange, enemyLayers);

        foreach (Collider2D hit in hitEnemies)
        {
            if (hit.tag == "Enemy")
            {
                if (hit.gameObject.GetComponent<HealthSystem>() != null)
                {
                    hit.GetComponent<HealthSystem>().TakeDamage(sDamage + stats.Strength * 2);
                }
            }
        }
    }

    #endregion

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
