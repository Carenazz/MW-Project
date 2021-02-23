using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrPotion : MonoBehaviour
{
    Stats stats;

    private void Awake()
    {
        stats.GetComponent<Stats>();
    }

    public void OnClick()
    {
        stats.str = stats.str + 2;
        Destroy(this);
    }
}
