using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Pathfinding;

public class Follow : MonoBehaviour
{

    public float speed, nextWpDist;

    Path path;
    int currentWp;
    bool reachedEndOfPath = false;
    private Transform target;

    Seeker seeker;
    Rigidbody2D rb;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

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



    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < 7)
        {
            if (path != null)
            {
                if (currentWp >= path.vectorPath.Count)
                {
                    reachedEndOfPath = true;
                    return;
                }
                else
                {
                    reachedEndOfPath = false;
                }
            }
            Updater();
        }
    }

    public void Updater()
    {
        Vector2 direction = ((Vector2)path.vectorPath[currentWp] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWp]);

        if (distance < nextWpDist)
        {
            currentWp++;
        }
    }
}
