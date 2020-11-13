using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    public float speed;

    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.8)
        { 
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

    }
}
