using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : HiroMonoBehavior
{
    public JunkCtrl junkCtrl;
    public int dropCount = 0;
    public List<ItemDropCount> dropCounts = new List<ItemDropCount>();

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(Droping), 2, 0.5f);
    }

    protected virtual void Droping() 
    {
        dropCount += 1;
        Vector3 dropPos = transform.position;
        Quaternion rot = transform.rotation;
        List<ItemDropRate> droppedItems = ItemDropSpawner.Instance.Drop(junkCtrl.ShootableObject.dropList, dropPos, rot);
        ItemDropCount itemDropCount;

        foreach(ItemDropRate item in droppedItems) 
        {
            itemDropCount = dropCounts.Find(i => i.itemName == item.itemSO.itemName);

            if(itemDropCount == null)
            {
                itemDropCount = new ItemDropCount();
                itemDropCount.itemName = item.itemSO.itemName;

                dropCounts.Add(itemDropCount);
            }

            itemDropCount.count += 1;
            itemDropCount.rate = (float)Math.Round((float)itemDropCount.count / dropCount, 2);
        }
    }
}

[Serializable]
public class ItemDropCount
{
    public string itemName;
    public int count;
    public float rate;
}
