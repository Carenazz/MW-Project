using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigAtt : MonoBehaviour
{
    #region Variables
    public int attackDamage = 20;
    public float attackRange = 2f;

    public Vector3 attackOffset;
    public LayerMask attackMask;
    #endregion

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerControls>().TakeDamage(attackDamage);
        }
    }
}
