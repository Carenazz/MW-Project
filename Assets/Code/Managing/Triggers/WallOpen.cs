using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpen : MonoBehaviour
{
    #region variables
    Vector3 startPos;

    [SerializeField]
    private float speed = 2f;
    private bool moved = false;

    Enabler enable;
    public Transform target;
    #endregion

    void Start()
    {
        enable = GetComponent<Enabler>();
    }

    void Update()
    {
        if (enable.Button())
        {
            Move();
        }
    }

    public void Move()
    {
        float step = speed * Time.deltaTime;

        if (!moved)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            moved = true;
        }
        else if (moved)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            moved = false;
        }
    }
}
