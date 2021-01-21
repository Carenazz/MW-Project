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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attacking");

                nextAttack = Time.time + 1.5f / attackRate / (stats.agility / 3);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("StrAtt");

                nextAttack = Time.time + 3f / attackRate / (stats.agility / 3);
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
                    hit.GetComponent<EnemyHP>().TakeDamage(attackDamage + stats.str);
                }
                else if (hit.gameObject.GetComponent<BossHP>() != null)
                {
                    hit.GetComponent<BossHP>().TakeDamage(attackDamage + stats.str);
                }
                else if (hit.gameObject.GetComponent<HyenaHP>() != null)
                {
                    hit.GetComponent<HyenaHP>().TakeDamage(attackDamage + stats.str);
                }
                else if (hit.gameObject.GetComponent<VultureHP>() != null)
                {
                    hit.GetComponent<VultureHP>().TakeDamage(attackDamage + stats.str);
                }
                else if (hit.gameObject.GetComponent<SnowHP>() != null)
                {
                    hit.GetComponent<SnowHP>().TakeDamage(attackDamage + stats.str);
                }
                if (hit.gameObject.GetComponent<VikingHP>() != null)
                {
                    hit.GetComponent<VikingHP>().TakeDamage(attackDamage + stats.str);
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
                    hit.GetComponent<EnemyHP>().TakeDamage(sDamage + stats.str * 2);
                }
                else if (hit.gameObject.GetComponent<BossHP>() != null)
                {
                    hit.GetComponent<BossHP>().TakeDamage(sDamage + stats.str * 2);
                }
                else if (hit.gameObject.GetComponent<HyenaHP>() != null)
                {
                    hit.GetComponent<HyenaHP>().TakeDamage(sDamage + stats.str * 2);
                }
                else if (hit.gameObject.GetComponent<VultureHP>() != null)
                {
                    hit.GetComponent<VultureHP>().TakeDamage(sDamage + stats.str * 2);
                }
                else if (hit.gameObject.GetComponent<SnowHP>() != null)
                {
                    hit.GetComponent<SnowHP>().TakeDamage(attackDamage + stats.str * 2);
                }
                if (hit.gameObject.GetComponent<VikingHP>() != null)
                {
                    hit.GetComponent<VikingHP>().TakeDamage(attackDamage + stats.str * 2);
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
