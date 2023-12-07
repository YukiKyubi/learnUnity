using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : HiroMonoBehavior
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl() {
        if(playerCtrl != null) return;

        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();

        Debug.Log(transform.name + ": Load PlayerCtrl", gameObject);
    }
}
