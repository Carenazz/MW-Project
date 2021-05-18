using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrPotion : MonoBehaviour
{
    Stats stats;
    private bool isUsed = false;

    private void Awake()
    {
        stats.GetComponent<Stats>();
    }

    public void OnClick()
    {
        if (!isUsed)
        {
            stats.str += 2;
            Destroy(this);
            isUsed = true;
        }
        else
        {
            // Få en tekst til at sige at der allerede er en effekt i gang.
        }
    }
}
