using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingMove : MonoBehaviour
{
    #region Variables
    Rigidbody2D rb;
    Animator anim;

    [SerializeField]
    private float speed = 2f, dist = 12f;

    VikingHP hp;
    Transform player;
    private bool isFlipped = false;
    #endregion

    void Start()
    {
        hp = GetComponent<VikingHP>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    #region Follow & Look for Statemachine
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

    public void FollowPlayer()
    {
        if (!hp.dead)
        {
            if (Vector3.Distance(player.position, transform.position) > dist)
            {
                Vector3 direction = player.position - this.transform.position;
                direction.y = 0;
                anim.SetBool("Idle", false);
            }

            if (Vector3.Distance(player.position, transform.position) < dist)
            {
                Vector3 direction = player.position - this.transform.position;
                direction.y = 0;
                transform.position += direction.normalized * speed * Time.deltaTime;
                anim.SetBool("Idle", true);
            }
        }
    }
        #endregion
}
