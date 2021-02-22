using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
   public enum ItemType
    {
        HealthPotion, ManaPotion, StrPotion, AgiPotion, StaPotion, WillPotion
    }

    public ItemType itemType;
    public int amount;
}
