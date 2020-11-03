using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossScript : MonoBehaviour
{
    #region variables
    Transform target;
    Rigidbody2D rb;
    Transform player;
    Seeker seeker;
    Path path;

    public float speed = 2.5f, nextWpD = 3f;
    int currentWp = 0;
    bool reachEOP = false;
    public bool isFlipped = false;
    #endregion

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        target = player;
    }

    #region Path
    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWp = 0;
        }
    }
    #endregion

    private void FixedUpdate()
    {
        if (path != null)
        {
            if (currentWp >= path.vectorPath.Count)
            {
                reachEOP = true;
                return;
            }
            else
                reachEOP = false;
        }
    }

    #region Look and Follow
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
        // Hvorfor breaker linjen nedenunder spillet? (Question or find potential fix)
        Vector2 direction = ((Vector2)path.vectorPath[currentWp] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWp]);

        if (distance < nextWpD)
        {
            currentWp++;
        }
    }
    #endregion
}
