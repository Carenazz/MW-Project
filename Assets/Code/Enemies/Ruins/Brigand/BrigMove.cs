using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigMove : MonoBehaviour
{
    #region variables
    [SerializeField]
    private float speed = 3f, stopDistance, fdist = 10f;

    private bool isFlipped = false;
    Transform player;
    #endregion

    #region Components
    Rigidbody2D rb;
    BrigHP hp;
    Animator anim;
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
        if (hp.currentHealth > 0)
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
}
