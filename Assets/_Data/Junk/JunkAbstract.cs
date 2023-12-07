using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : HiroMonoBehavior
{
    [SerializeField] protected JunkCtrl junkCtrl;

    public JunkCtrl JunkCtrl { get => junkCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCrtl();
    }

    protected virtual void LoadJunkCrtl() {
        if(junkCtrl != null) return;
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": Load JunkCrtl", gameObject);
    }
}
