using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemCollector : InventoryAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
        LoadRigidBody();
    }

    protected virtual void LoadCollider() {
        if(sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.3f;
        Debug.Log(transform.name + ": Load Collider", gameObject);
    }

    protected virtual void LoadRigidBody() {
        if(_rigidbody != null) return;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;

        Debug.Log(transform.name + ":Load RigidBody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider) {
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();

        if(itemPickupable == null) return;

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;

        if(inventory.AddItem(itemInventory)) {
            itemPickupable.Picked();
        }
    }
}
