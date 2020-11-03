using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class VikingAI : MonoBehaviour
{
    #region variables
    public Transform player;

    public float speed, nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachEOP = false;

    Seeker seeker;
    Rigidbody2D rb;
    #endregion

    void Start()
    {
        #region Components & Transform.
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        #endregion
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    #region Path
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
    #endregion

    void FixedUpdate()
    {
        #region path is null?
        if (path != null)
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachEOP = true;
                return;

            }
            else
            {
                reachEOP = false;
            }
        }
        #endregion
    }

    public void Updater()
    {
        Vector2 velocity = new Vector2((transform.position.x - player.position.x) * speed, (transform.position.y - player.position.y) * speed);
        rb.velocity = -velocity;
    }
}
