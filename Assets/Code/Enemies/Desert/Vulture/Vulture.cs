using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulture : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 1.5f;

    VultureMovement move;
    Rigidbody2D rb;
    VultureHP hp;

    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        move = animator.GetComponent<VultureMovement>();
        rb = animator.GetComponent<Rigidbody2D>();
        hp = animator.GetComponent<VultureHP>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        if (hp.currentHealth > 0)
        {

            move.LookAtPlayer();

            move.Follow();

            animator.SetFloat("Speed", Mathf.Abs(speed));

            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");

            }
        }
        else if (hp.currentHealth <= 0)
        {
            animator.SetBool("Dead", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        animator.ResetTrigger("Attack");
    }
}
