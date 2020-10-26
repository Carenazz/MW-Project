﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingAttack : MonoBehaviour
{
    #region Variables
    public int attackDamage = 30;

    public Vector3 attackOffset;
    public float attackRange = 1f;
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
