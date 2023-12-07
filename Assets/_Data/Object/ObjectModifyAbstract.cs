using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectModifyAbstract : HiroMonoBehavior
{
    [Header("Modify")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl() {
        if(shootableObjectCtrl != null) return;

        shootableObjectCtrl = GetComponent<ShootableObjectCtrl>();

        Debug.Log(transform.name + ": Load ShootableObjectCtrl", gameObject);
    }
}
