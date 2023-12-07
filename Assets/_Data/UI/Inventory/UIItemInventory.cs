using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : HiroMonoBehavior
{
    [Header("UI Item Inventory")]
    [SerializeField] protected ItemInventory item;

    public ItemInventory Item => item;

    [SerializeField] protected Text itemName;

    public Text ItemName => itemName;

    [SerializeField] protected Text itemNum;

    public Text ItemNum => itemNum;

    [SerializeField] protected Image itemSprite;

    public Image ItemSprite => itemSprite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemName();
        LoadItemNumber();
        LoadItemSprite();
    }

    protected virtual void LoadItemName()
    {
        if(itemName != null) return;

        itemName = transform.Find("ItemName").GetComponent<Text>();

        Debug.LogWarning(transform.name + ": Load ItemName", gameObject);
    }

    protected virtual void LoadItemNumber()
    {
        if(itemNum != null) return;

        itemNum = transform.Find("ItemNum").GetComponent<Text>();

        Debug.LogWarning(transform.name + ": Load ItemNumber", gameObject);
    }

    protected virtual void LoadItemSprite()
    {
        if(itemSprite != null) return;

        itemSprite = transform.Find("ItemSprite").GetComponent<Image>();

        Debug.LogWarning(transform.name + ": Load ItemSprite", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.item = item;
        itemName.text = this.item.itemProfile.itemName;
        itemNum.text = this.item.itemCount.ToString();
        itemSprite.sprite = this.item.itemProfile.sprite;
    }
}
