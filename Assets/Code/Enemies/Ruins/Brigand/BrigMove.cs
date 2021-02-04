using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigMove : MonoBehaviour
{
    #region variables
    Rigidbody2D rb;

    [SerializeField]
    private float speed = 2.5f, stopDistance, fdist = 10f;

    BrigHP hp;
    Animator anim;

    Transform player;
    private bool isFlipped = false;
    #endregion

    void Awake()
    {
        #region Components
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        hp = GetComponent<BrigHP>();
        anim = GetComponent<Animator>();
        #endregion
    }

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

    public void ChasePlayer()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.position) < fdist)
        {
            rb.MovePosition(newPos);
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
        }
    }
}
