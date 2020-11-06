using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingAttack : MonoBehaviour
{
    #region Variables
    public int attackDamage = 30;

    public Vector3 attackOffset;
    public float attackRange = 1f, timer = 2f, timeBAtt = 2f;
    public LayerMask attackMask;
    #endregion

    private void Update()
    {
        if (timer >= 0f)
        {
            timer -= Time.deltaTime;    
        }
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        if (timer <= 0f)
        {
            Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colInfo != null)
            {
                colInfo.GetComponent<PlayerControls>().TakeDamage(attackDamage);
                timer = 5f / timeBAtt;
            }
        }
    }
}
