using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : HiroMonoBehavior
{
    [SerializeField] protected ItemDespawn itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;

    public ItemDespawn ItemDespawn => itemDespawn;

    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
        LoadItemInventory();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetItem();
    }

    protected virtual void LoadItemDespawn() {
        if(itemDespawn != null) return; 

        itemDespawn = transform.GetComponentInChildren<ItemDespawn>();

        Debug.Log(transform.name + ": Load ItemDespawn", gameObject);
    }

    protected virtual void LoadItemInventory() {
        if(itemInventory.itemProfile != null) return;

        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        itemInventory.itemProfile = itemProfile;
        itemInventory.itemCount = 1;

        if(itemProfile.itemType == ItemType.Equipment) itemInventory.maxStack = 1;

        ResetItem();
        Debug.Log(transform.name + ": Load ItemInventory", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory) {
        this.itemInventory = itemInventory.Clone();
    }

    protected virtual void ResetItem() {
        itemInventory.itemCount = 1;
        itemInventory.upgradeLevel = 0;
    }
}
