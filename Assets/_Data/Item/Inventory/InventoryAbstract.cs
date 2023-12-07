using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : HiroMonoBehavior
{
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventory();
    }

    protected virtual void LoadInventory() {
        if(inventory != null) return;

        inventory = transform.parent.GetComponent<Inventory>();

        Debug.Log(transform.name + ": Load Inventory", gameObject);
    }
}
