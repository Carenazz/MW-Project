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

    public Transform target;
    public LayerMask whatIsPlayer;
    #endregion

    void Update()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, whatIsPlayer);

        if (Input.GetKeyDown(KeyCode.E) && playerInfo == GameObject.FindGameObjectWithTag("Player"))
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
