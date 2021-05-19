using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGolemAtt : MonoBehaviour
{

    #region Variables

    Animator anim;

    public Transform attackPoint;

    public LayerMask playerLayer;

    PlayerHealth hp;
    private Transform player;

    [SerializeField]
    private float attackRange = 0.5f, attackRate = 2f, nextAttack = 0f, distance = 2f;
    public int attackDamage = 25;

    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        hp = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.left, distance, playerLayer);
        RaycastHit2D rHit = Physics2D.Raycast(transform.position, Vector2.right, distance, playerLayer);

        if (Time.time >= nextAttack)
        {
            if (hitInfo != gameObject.CompareTag("Player") || rHit != gameObject.CompareTag("Player"))
            {
                anim.SetTrigger("Attack");

                nextAttack = Time.time + 3f / attackRate;
            }
        }
    }

    void Attack()
    {
        RaycastHit2D stayInfo = Physics2D.Raycast(transform.position, Vector2.left, distance, playerLayer);
        RaycastHit2D rStay = Physics2D.Raycast(transform.position, Vector2.right, distance, playerLayer);

        if (stayInfo == GameObject.FindGameObjectWithTag("Player") || rStay == GameObject.FindGameObjectWithTag("Player"))
        {
            hp.TakeDamage(attackDamage);
        }
    }
}
