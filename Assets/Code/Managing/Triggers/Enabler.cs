using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    #region Gameobjects
    public GameObject level;
    public GameObject newCP;
    public GameObject cp;
    [SerializeField]
    private Collider2D m_coll;
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    #endregion

    private void Start()
    {
        m_coll = gameObject.GetComponent<Collider2D>();
        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Enabled()
    {
        m_coll.enabled = true;
        m_spriteRenderer.enabled = true;
    }

    public void CheckEnable()
    {
        newCP.SetActive(true);
    }

    public void CheckDisable()
    {
        cp.SetActive(false);
    }
}
