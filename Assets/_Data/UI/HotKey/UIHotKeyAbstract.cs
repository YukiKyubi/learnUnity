using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHotKeyAbstract : HiroMonoBehavior
{
    [SerializeField] protected UIHotKeyCtrl hotKeyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIHotKeyCtrl();
    }

    protected void LoadUIHotKeyCtrl()
    {
        if(hotKeyCtrl != null) return;

        hotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();

        Debug.LogWarning(transform.name + ": Load UIHotKeyCtrl", gameObject);
    }
}
