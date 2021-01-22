using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanging : MonoBehaviour
{
    #region Variables
    private int distance;
    private bool isHanging;
    #endregion

    #region Components and layermasks
    public LayerMask whatIsPlatform;
    public Animator anim;
    #endregion

    public void HangCheck()
    {
        RaycastHit2D hangInfo = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsPlatform);
        
        if (hangInfo.collider != null)
        {
            isHanging = true;
            // Animation for hanging.

            if (isHanging == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    // Animation for pull up
                    isHanging = false;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    // Animation for at slippe
                    isHanging = false;
                }
            }
        }
        else
        {
            isHanging = false;
        }
    }

}
