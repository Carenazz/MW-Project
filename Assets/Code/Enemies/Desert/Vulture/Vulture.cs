using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulture : StateMachineBehaviour
{
    [SerializeField]
    private float speed = 2.5f, attackRange = 1.5f, timer = 1.2f;

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
            #region movement region
            move.LookAtPlayer();

            move.Follow();

            animator.SetFloat("Speed", Mathf.Abs(speed));
            #endregion

            #region Attack Region
            if (Vector2.Distance(player.position, rb.position) <= attackRange && timer <= 0f)
            {
                animator.SetTrigger("Attack");
                timer = 1.2f;
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
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        animator.ResetTrigger("Attack");
    }
}
