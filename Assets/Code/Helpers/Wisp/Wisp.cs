using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : StateMachineBehaviour
{
    public float healRange = 3f;
    Rigidbody2D rb;

    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.position, rb.position) <= healRange)
        {
            animator.SetTrigger("Heal");

        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Heal");
    }
}
