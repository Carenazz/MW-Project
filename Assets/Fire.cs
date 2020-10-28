using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 9f;
    public int damage = 20;
    public Rigidbody2D rigid;

    void Start()
    {
        rigid.velocity = transform.right * speed;    
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHP enemy = hitInfo.GetComponent<EnemyHP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
