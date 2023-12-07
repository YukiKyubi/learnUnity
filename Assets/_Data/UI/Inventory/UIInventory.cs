using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    private static UIInventory instance;

    public static UIInventory Instance => instance;

    protected bool isOpen = false;

    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;

    protected override void Awake()
    {
        base.Awake();

        if(instance != null) Debug.LogError("Only 1 UIInventory is allowed to exist");

        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        Close();
        InvokeRepeating(nameof(ShowItems), 1, 1);
    }

    protected virtual void FixedUpfate()
    {
        //ShowItem();
    }

    public virtual void Toggle()
    {
        isOpen = !isOpen;

        if(isOpen) Open();
        else Close();
    }

    public virtual void Open()
    {
        inventoryCtrl.gameObject.SetActive(true);
        
        isOpen = true;
    }

    public virtual void Close()
    {
        inventoryCtrl.gameObject.SetActive(false);

        isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if(!isOpen) return;
        ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.ShipCtrl.Inventory.Items;
        UIInvItemSpawner uiItemSpawner = inventoryCtrl.UiInvSpawner;

        foreach(ItemInventory item in items)
        {
            uiItemSpawner.SpawnItem(item);
        }

        SortItem();
    }

    protected virtual void SortItem()
    {
        if(inventorySort == InventorySort.NoSort) return;

        int itemCount = inventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        string currentItemName, nextItemName;
        int currentCount, nextCount;

        for(int i = 0; i < itemCount - 1; i++)
        {
            for(int j = itemCount - 1; j > i; j--)
            {
                currentItem = inventoryCtrl.Content.GetChild(j);
                nextItem = inventoryCtrl.Content.GetChild(j - 1);
                currentUIItem = currentItem.GetComponent<UIItemInventory>();
                nextUIItem = nextItem.GetComponent<UIItemInventory>();

                switch(inventorySort)
                {
                    case InventorySort.ByName:
                        currentItemName = currentUIItem.Item.itemProfile.itemName;
                        nextItemName = nextUIItem.Item.itemProfile.itemName;

                        if(string.Compare(nextItemName, currentItemName) > 0)
                            SwapItems(currentItem, nextItem);

                        break;
                    case InventorySort.ByCount:
                        currentCount = currentUIItem.Item.itemCount;
                        nextCount = nextUIItem.Item.itemCount;

                        if(nextCount > currentCount)
                            SwapItems(currentItem, nextItem);

                        break;
                }
            }
        }
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

    protected virtual void ClearItems()
    {
        inventoryCtrl.UiInvSpawner.ClearItems();
    }
}
