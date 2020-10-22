using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latch : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public Transform follower;

    public void Update()
    {
        RaycastHit2D playerinfo = Physics2D.Raycast(follower.position, Vector2.up, 2f);
        if (playerinfo.collider != null)
        {
            if (playerinfo.collider.transform.tag == "Player")
            {
                Follow();
            }
        }
    }
    public void Follow()
    {
        follower.transform.SetParent(follower);
        Debug.Log("I hit player and tried to latch onto him");
    }
}
