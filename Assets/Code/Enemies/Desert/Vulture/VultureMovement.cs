using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class VultureMovement : MonoBehaviour
{
    Rigidbody2D rb;
    EnemyAI ai;
    Path path;

    Seeker seeker;

    public float speed = 3f, fSpeed = 5, xDistance = 14f;
    int currentWaypoint = 0;

    public float nextWaypointDistance = 3f;

    public bool isFlipped = false, moveLeft;
    bool reachedEndOfPath;

    Transform player;

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, player.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        ai = GetComponent<EnemyAI>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
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

    private void FixedUpdate()
    {
        if (path != null)
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
        }
    }
}
