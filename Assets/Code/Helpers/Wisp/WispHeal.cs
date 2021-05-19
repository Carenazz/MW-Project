using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispHeal : MonoBehaviour
{
    public int heal = 2;

    public Vector3 healOffset;
    public float healRange = 2f;
    public LayerMask healMask;

    public void Heal()
    {
        Vector3 pos = transform.position;
        pos += transform.right * healOffset.x;
        pos += transform.up * healOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, healRange, healMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().Healed(heal);
        }
    }
}
