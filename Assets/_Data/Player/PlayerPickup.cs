using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable) {
        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;

        if(playerCtrl.ShipCtrl.Inventory.AddItem(itemInventory)) {
            itemPickupable.Picked();
        }
    }
}
