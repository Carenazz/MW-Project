using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int str, stamina, will;
    public float agility;

    private void Start()
    {
        str = 2;
        stamina = 1;
        will = 1;
        agility = 2f;
    }
}
