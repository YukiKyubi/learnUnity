using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : HiroMonoBehavior
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        base.Start();
        AddItem(ItemCode.CopperSword, 1);
        AddItem(ItemCode.IronOre, 10);
        AddItem(ItemCode.GoldOre, 10);
    }

    public virtual bool AddItem(ItemInventory itemInventory) {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfile;
        ItemCode itemCode = itemProfile.itemCode;
        ItemType itemType = itemProfile.itemType;

        if(itemType == ItemType.Equipment) return AddEquipment(itemInventory);
        return AddItem(itemCode, addCount);
    }

    public virtual bool AddEquipment(ItemInventory itemInventory) {
        if(IsFull()) return false;

        ItemInventory item = itemInventory.Clone();

        items.Add(item);
        return true;
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount) {
        ItemProfileSO itemProfile = GetItemProfile(itemCode);
        int addRemain = addCount;
        int newCount, itemMaxStack, addMore;
        ItemInventory itemExist;

        for(int i = 0; i < maxSlot; i++) {
            itemExist = GetItemNotFullStack(itemCode);

            if(itemExist == null) {
                if(IsFull()) return false;

                itemExist = CreateEmptyItem(itemProfile);

                items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;
            itemMaxStack = GetMaxStack(itemExist);

            if(newCount > itemMaxStack) {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else {
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount;

            if(addRemain < 1) break;
        }

        return true;
    }

    protected virtual bool IsFull() {
        if(items.Count >= maxSlot) return true;
        return false;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode) {
        foreach(ItemInventory item in items) {
            if(itemCode != item.itemProfile.itemCode) continue;
            if(IsFullStack(item)) continue;

            return item;
        }

        return null;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory) {
        if(itemInventory == null) return 0;

        return itemInventory.maxStack; 
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode) {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));

        foreach(ItemProfileSO profile in profiles) {
            if(profile.itemCode != itemCode) continue;

            return profile;
        }

        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory) {
        if(itemInventory == null) return true;

        int maxStack = GetMaxStack(itemInventory);

        return itemInventory.itemCount >= maxStack;
    }
    
    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile) {
        ItemInventory itemInventory = new ItemInventory {
            itemId = ItemInventory.RandomId(),
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };

        return itemInventory;
    }

    public virtual bool ItemCheck(ItemCode itemCode, int itemCount) {
        int totalCount = ItemTotalCount(itemCode);

        return totalCount >= itemCount;
    }

    protected virtual int ItemTotalCount(ItemCode itemCode) {
        int totalCount = 0;

        foreach(ItemInventory itemInventory in items) {
            if(itemInventory.itemProfile.itemCode != itemCode) continue;
            
            totalCount += itemInventory.itemCount;
        }

        return totalCount;
    }

    public virtual void DeductItems(ItemCode itemCode, int number) {
        ItemInventory itemInventory;
        int deduct;

        for(int i = items.Count - 1; i >= 0; i--) {
            if(number <= 0) break;

            itemInventory = items[i];

            if(itemInventory.itemProfile.itemCode != itemCode) continue;

            if(number > itemInventory.itemCount) {
                deduct = itemInventory.itemCount;
                number -= itemInventory.itemCount;
            }
            else {
                deduct = number;
                number = 0;
            }

            itemInventory.itemCount -= deduct;
        }

        ClearEmptySlot();
    }

    protected virtual void ClearEmptySlot() {
        ItemInventory itemInventory;

        for(int i = 0; i < items.Count; i++) {
            itemInventory = items[i];
            
            if(itemInventory.itemCount == 0) items.RemoveAt(i);
        }
    }

    // public virtual bool AddItem(ItemCode itemCode, int addCount) {
    //     ItemInventory itemInventory = GetItemByCode(itemCode);
    //     int newCount = itemInventory.itemCount + addCount;

    //     if(newCount > itemInventory.maxStack) return false;

    //     itemInventory.itemCount = newCount;

    //     return true;
    // }

    // protected virtual ItemInventory GetItemByCode(ItemCode itemCode) {
    //     ItemInventory itemInventory = items.Find(item => item.itemProfile.itemCode == itemCode);
    //     if(itemInventory == null) itemInventory = AddNewItemProfile(itemCode);
    //     return itemInventory;
    // }

    // protected virtual ItemInventory AddNewItemProfile(ItemCode itemCode) {
    //     var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));

    //     foreach(ItemProfileSO profile in profiles) {
    //         if(profile.itemCode != itemCode) continue;

    //         ItemInventory itemInventory = new ItemInventory {
    //             itemProfile = profile,
    //             maxStack = profile.defaultMaxStack
    //         };

    //         items.Add(itemInventory);
    //         return itemInventory;
    //     }

    //     return null;
    // }
}
