using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigStateMachine : StateMachineBehaviour
{
    #region Variables
    [SerializeField]
    private float speed = 0f, attackRange = 1.5f, timer = 1f;

    Transform player;
    #endregion

    #region Components
    Rigidbody2D rb;
    BrigHP hp;
    BrigMove move;
    #endregion

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Getting Components
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        move = animator.GetComponent<BrigMove>();
        hp = animator.GetComponent<BrigHP>();
        #endregion
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region HP if / else
        if (hp.currentHealth > 0)
        {
            #region Movement
            move.LookAtPlayer();

            move.ChasePlayer();
            #endregion

            #region Attack
            if (Vector2.Distance(player.position, rb.position) <= attackRange && timer <= 0f)
            {
                animator.SetTrigger("Attack");
                timer = 1f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            #endregion
        }
        else if (hp.currentHealth <= 0)
        {
            animator.SetBool("Dead", true);
        }
        #endregion
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
