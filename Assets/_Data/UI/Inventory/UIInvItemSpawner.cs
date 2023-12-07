using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;

    public static UIInvItemSpawner Instance => instance;

    [Header("Inventory Item")]
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;

    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;

    public static string normalItem = "UIInvItem";

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 UIInvItemSpawner is allowed to exist");

        instance = this;
    }

    protected override void LoadHolder()
    {
        LoadUIInventoryCtrl();
        if(holder != null) return;

        holder = uIInventoryCtrl.Content;

        Debug.LogWarning(transform.name + ": Load Holder", gameObject);
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if(uIInventoryCtrl != null) return;

        uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();

        Debug.LogWarning(transform.name + ": Load UIInventoryCtrl", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach(Transform item in holder)
        {
            Despawn(item);
        }
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiInvItem = Spawn(normalItem, Vector3.zero, Quaternion.identity);
        uiInvItem.transform.localScale = new Vector3(1, 1, 1);
        UIItemInventory uIItemInventory = uiInvItem.GetComponent<UIItemInventory>();

        uIItemInventory.ShowItem(item);

        uiInvItem.gameObject.SetActive(true);
    }
}
