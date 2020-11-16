using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpen : MonoBehaviour
{
    #region variables

    [SerializeField]
    private float speed = 2f, timer = 1.5f;
    private bool moved = false;

    public GameObject target;

    public LayerMask whatIsPlayer;
    #endregion

    void Update()
    {
        RaycastHit2D playerInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, whatIsPlayer);

        if (Input.GetKeyDown(KeyCode.E) && playerInfo == GameObject.FindGameObjectWithTag("Player") && timer <= 0f)
        {
            Move();
        }
        else
            timer -= Time.deltaTime;
    }

    // Mål: Få target til at bevæge sig mod et andet target.
    public void Move()
    {
        if (!moved)
        {
            target.SetActive(false);
            moved = true;
            timer = 1.5f;
        }
        else if (moved)
        {
            target.SetActive(true);
            moved = false;
            timer = 1.5f;
        }
    }
}
