using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemDropper : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        //Invoke(nameof(Test), 5);
    }

    protected virtual void Test() {
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        DropItem(0, dropPos, transform.rotation);
    }

    protected virtual void DropItem(int itemIndex, Vector3 dropPos, Quaternion rotation) {
        ItemInventory itemInventory = inventory.Items[itemIndex];

        ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, rotation);
        inventory.Items.Remove(itemInventory);
    }
}
