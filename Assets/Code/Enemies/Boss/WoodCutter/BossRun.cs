﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    #region variables
    [SerializeField]
    private float speed = 2.5f, attackRange = 3f, timer = 2f;
    private bool isDead = false;

    Transform player;
    Rigidbody2D rb;
    BossScript boss;
    BossJump jump;
    #endregion


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Getting Components
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossScript>();
        jump = animator.GetComponent<BossJump>();
        #endregion
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Movements
        boss.LookAtPlayer();

        boss.FollowPlayer();

        jump.Jump();
        #endregion

        #region Attack
        if (Vector2.Distance(player.position, rb.position) <= attackRange && timer <= 0f)
        {
            animator.SetTrigger("Attacking");
            timer = 2f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        #endregion
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attacking");
    }
}
