using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : HiroMonoBehavior
{
    private static UIHotKeyCtrl instance;

    public static UIHotKeyCtrl Instance => instance;

    public List<ItemSLot> itemSLots;

    protected override void Awake()
    {
        base.Awake();

        if(instance != null) Debug.LogError("Only 1 UIHotKeyCtrl is allowed to exist");

        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if(itemSLots.Count > 0) return;

        ItemSLot[] arraySlots = GetComponentsInChildren<ItemSLot>();

        itemSLots.AddRange(arraySlots);

        Debug.Log(transform.name + ": Load ItemSlots", gameObject);
    }
}
