using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject cp;
    public GameObject oldCP;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            cp.SetActive(true);
            oldCP.SetActive(false);
        }
    }
}
