using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    #region variables
    public Animator animator;
    EnemyHP myHP;

    [SerializeField]
    private float timeBetweenAttacks = 1.5f, distance = 0.5f, detectDistance = 2f, timer = 0f;

    public int attackDamage = 20;
    public Transform hitDetection;

    public LayerMask whatIsPlayer;

    // enemy movement

    public float speed;
    private bool movingLeft = true;

    public Transform wallDetection;

    // Detect player
    private Transform player;
    PlayerControls playerHealth;
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerControls>();
        myHP = GetComponent<EnemyHP>();
    }

    void Attack()
    {
            playerHealth.TakeDamage(attackDamage);
    }

    private void Update()
    {
        if (myHP.currentHealth >= 0)
        {
            if (timer <= 0f)
            {
                #region Collision + Attack
                RaycastHit2D hitInfo = Physics2D.Raycast(hitDetection.position, Vector2.up, distance);
                Debug.DrawRay(hitDetection.position, Vector2.up, Color.red);
                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.transform.tag == "Player")
                    {
                        timer = 2 / timeBetweenAttacks;

                        animator.SetTrigger("Attack");
                    }
                }
                #endregion
            }
            else if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }

            transform.Translate(Vector2.left * speed * Time.deltaTime);

            animator.SetFloat("Speed", Mathf.Abs(speed));

            #region Raycast detecting wall
            RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, distance);
            Debug.DrawRay(wallDetection.position, Vector2.left, Color.red);
            if (wallInfo.collider != null)
            {
                if (wallInfo.collider.transform.tag == "Wall" || wallInfo.collider.transform.tag == "Platform")
                {
                    if (movingLeft == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingLeft = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingLeft = true;
                    }
                }
            }
            #endregion
        }
    }
}
