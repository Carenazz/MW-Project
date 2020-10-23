using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = transform.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0, y = 0;
        float itemSlotCellSize = 30f;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform iSlotRT = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            iSlotRT.gameObject.SetActive(true);
            iSlotRT.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x++;
            if (x > 6)
            {
                x = 0;
                y++;
            }
        }
    }
}
