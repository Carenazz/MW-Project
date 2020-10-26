using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    Rigidbody2D rb;

    [SerializeField]
    private float speed = 2.5f, stopDistance, fdist = 10f;

    EnemyHP hp;
    Animator anim;

    Transform player;
    public bool isFlipped = false;

    #endregion

    private void Awake()
    {
        #region Components
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        hp = GetComponent<EnemyHP>();
        anim = GetComponent<Animator>();
        #endregion
    }

    #region Movement System
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void FollowPlayer()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.position) < fdist)
        {
            rb.MovePosition(newPos);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isIdle", true);
        }
    }
    #endregion
}
