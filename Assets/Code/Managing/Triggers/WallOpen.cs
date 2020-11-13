using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpen : MonoBehaviour
{
    #region variables

    [SerializeField]
    private float speed = 2f;
    private bool moved = false;

    public GameObject target;

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
        if (!moved)
        {
            target.SetActive(false);
            moved = true;
        }
        else if (moved)
        {
            target.SetActive(true);
            moved = false;
        }
    }
}
