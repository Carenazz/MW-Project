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
    #endregion

    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attacking");

                nextAttack = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("StrAtt");

                nextAttack = Time.time + 2f / attackRate;
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
                #region Working hits
                if (hit.gameObject.GetComponent<EnemyHP>() != null)
                {
                    hit.GetComponent<EnemyHP>().TakeDamage(attackDamage);
                }
                else if (hit.gameObject.GetComponent<BossHP>() != null)
                {
                    hit.GetComponent<BossHP>().TakeDamage(attackDamage);
                }
                else if (hit.gameObject.GetComponent<HyenaHP>() != null)
                {
                    hit.GetComponent<HyenaHP>().TakeDamage(attackDamage);
                }
                else if (hit.gameObject.GetComponent<VultureHP>() != null)
                {
                    hit.GetComponent<VultureHP>().TakeDamage(attackDamage);
                }
                else if (hit.gameObject.GetComponent<SnowHP>() != null)
                {
                    hit.GetComponent<SnowHP>().TakeDamage(attackDamage);
                }
                #endregion

                #region Testing hits
                #endregion
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
                #region Working hits
                if (hit.gameObject.GetComponent<EnemyHP>() != null)
                {
                    hit.GetComponent<EnemyHP>().TakeDamage(sDamage);
                }
                else if (hit.gameObject.GetComponent<BossHP>() != null)
                {
                    hit.GetComponent<BossHP>().TakeDamage(sDamage);
                }
                else if (hit.gameObject.GetComponent<HyenaHP>() != null)
                {
                    hit.GetComponent<HyenaHP>().TakeDamage(sDamage);
                }
                else if (hit.gameObject.GetComponent<VultureHP>() != null)
                {
                    hit.GetComponent<VultureHP>().TakeDamage(sDamage);
                }
                else if (hit.gameObject.GetComponent<SnowHP>() != null)
                {
                    hit.GetComponent<SnowHP>().TakeDamage(attackDamage);
                }
                #endregion

                #region Test hits
                #endregion
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
