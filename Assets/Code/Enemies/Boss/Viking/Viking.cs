using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : StateMachineBehaviour
{

    #region Variables
    [SerializeField]
    private float attackRange = 3f, timer = 3f;

    Transform player;

    Rigidbody2D rb;
    VikingMove move;
    #endregion

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region Getting Components
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        move = animator.GetComponent<VikingMove>();
        #endregion
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        #region VikingMovement
        move.LookAtPlayer();

        move.FollowPlayer();
        #endregion

        #region Attack
        if (Vector2.Distance(player.position, rb.position) <= attackRange && timer <= 0f)
        {
            animator.SetTrigger("Attack");
            timer = 3f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        #endregion
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
