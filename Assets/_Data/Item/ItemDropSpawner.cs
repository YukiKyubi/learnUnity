using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;

    public static ItemDropSpawner Instance => instance;

    [SerializeField] protected float gameDropRate = 1;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 ItemDropSpawner is allowed to exist");
        instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 dropPos, Quaternion rotation) {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        
        if(dropList.Count < 1) return droppedItems;

        droppedItems = DropItems(dropList);

        foreach(ItemDropRate item in droppedItems)
        {
            ItemCode itemCode = item.itemSO.itemCode;
            Transform itemDrop = Spawn(itemCode.ToString(), dropPos, rotation);

            if(itemDrop == null) continue;

            itemDrop.gameObject.SetActive(true);
        }

        return droppedItems;
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 dropPos, Quaternion rotation) {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = Spawn(itemCode.ToString(), dropPos, rotation);

        if(itemDrop == null) return null;

        itemDrop.gameObject.SetActive(true);

        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();

        itemCtrl.SetItemInventory(itemInventory);

        return itemDrop;
    }

    protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> items) 
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        float rate, itemRate;
        int itemDropMore;

        foreach(ItemDropRate item in items)
        {
            rate = Random.Range(0, 1);
            itemRate = item.dropRate / 100000f * GetGameDropRate();
            itemDropMore = Mathf.FloorToInt(itemRate);

            if(itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                
                for(int i = 0; i < itemDropMore; i++)
                {
                    droppedItems.Add(item);
                }
            }

            if(rate <= itemRate) 
            {
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    protected virtual float GetGameDropRate()
    {
        return gameDropRate;
    }
}
