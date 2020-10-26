using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : StateMachineBehaviour
{

    #region Variables
    [SerializeField]
    private float speed = 2.5f, attackRange = 3f;
    private bool isDead = false;

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
        move.LookAtPlayer();

        move.FollowPlayer();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
