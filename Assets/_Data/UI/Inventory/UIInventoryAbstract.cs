using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIInventoryAbstract : HiroMonoBehavior
{
    [Header("Inventory Abstract")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;

    public UIInventoryCtrl InventoryCtrl => inventoryCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIInventoryCtrl();
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if(inventoryCtrl != null) return;

        inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();

        Debug.LogWarning(transform.name + ": Load UIInventoryCtrl", gameObject);
    }
}
