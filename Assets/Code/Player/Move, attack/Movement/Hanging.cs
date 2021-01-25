using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanging : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private float distance;
    [SerializeField]
    private bool isHanging;

    public Transform hangPoint;
    #endregion

    #region Components and layermasks
    public LayerMask whatIsPlatform;
    public Animator anim;
    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HangCheck()
    {
        RaycastHit2D hangInfo = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsPlatform);
        Debug.DrawRay(transform.position, Vector2.down, Color.red, 1f);

        if (hangInfo.collider != null)
        {
            isHanging = true;
            anim.SetBool("IsHanging", true);
            // Animation for hanging.

            if (isHanging == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    // Animation for pull up
                    anim.SetBool("IsHanging", false);
                    anim.SetTrigger("HangPull");
                    isHanging = false;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    // Animation for at slippe
                    anim.SetBool("IsHanging", false);
                    anim.SetTrigger("HangFall");
                    isHanging = false;
                }
            }
        }
        else
        {
            isHanging = false;
            anim.SetBool("IsHanging", false);
        }
    }
}
