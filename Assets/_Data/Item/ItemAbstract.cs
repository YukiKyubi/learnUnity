using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbstract : HiroMonoBehavior
{
    [SerializeField] protected ItemCtrl itemCtrl;

    public ItemCtrl ItemCtrl => itemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl() {
        if(itemCtrl != null) return;

        itemCtrl = transform.GetComponentInParent<ItemCtrl>();

        Debug.Log(transform.name + ": Load ItemCtrl", gameObject);
    }
}
