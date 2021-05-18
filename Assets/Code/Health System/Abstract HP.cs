using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class AbstractHP : MonoBehaviour
{
    [SerializeField]
    protected double maxHealth, currentHealth;
    [SerializeField]
    protected Animator anim;
    [SerializeField]
    protected Rigidbody2D rigid;
    [SerializeField]
    protected Collider2D m_coll;

    void Start()
    {
        anim = GetComponent<Animator>();
        m_coll = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }
}
