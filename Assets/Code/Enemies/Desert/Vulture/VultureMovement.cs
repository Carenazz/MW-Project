using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureMovement : MonoBehaviour
{
    Rigidbody2D rb;
    EnemyAI ai;

    public float speed = 3f, fSpeed = 5, xDistance = 14f;
    int currentWaypoint = 0;

    public float nextWaypointDistance = 3f;

    public bool isFlipped = false, moveLeft;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        ai = GetComponent<EnemyAI>();
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

    public void Follow()
    {
        if (player.position.y < transform.position.y)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-fSpeed, rb.velocity.x);
        }
        else
        {
            rb.velocity = new Vector2(fSpeed, rb.velocity.x);
        }
    }
}
