using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyena : StateMachineBehaviour
{
    public float speed = 0f;
    public float attackRange = 1.5f;

    Transform player;
    Rigidbody2D rb;

    HyenaHP hp;
    Movement move;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        move = animator.GetComponent<Movement>();
        hp = animator.GetComponent<HyenaHP>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (hp.currentHealth > 0)
        {
            move.LookAtPlayer();

            move.FollowPlayer();

            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attacking");
            }

        }
        else if (hp.currentHealth <= 0)
        {
            animator.SetBool("Dead", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attacking");
    }
}
