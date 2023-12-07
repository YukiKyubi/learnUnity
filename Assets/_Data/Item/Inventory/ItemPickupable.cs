using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;

    public static ItemCode StringToItemCode(string itemName) {
        try {
            return (ItemCode)Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException e) {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }

    protected virtual void OnMouseDown() {
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
    }

    protected virtual void LoadCollider() {
        if(sphereCollider != null) return;

        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.2f;

        Debug.Log(transform.name + ": Load Collider", gameObject);
    }

    public virtual ItemCode GetItemCode() {
        return StringToItemCode(transform.parent.name);
    }

    public virtual void Picked() {
        itemCtrl.ItemDespawn.DespawnObject();
    }
}
