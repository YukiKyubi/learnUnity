using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : HiroMonoBehavior
{
    [Header("Item Spawner")]
    [SerializeField] protected Transform content;

    public Transform Content => content;

    [SerializeField] protected UIInvItemSpawner uiInvSpawner;

    public UIInvItemSpawner UiInvSpawner => uiInvSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadContent();
        LoadUIInvSpawner();
    }

    protected virtual void LoadContent()
    {
        if(content != null) return;

        content = transform.Find("Scroll View").Find("Viewport").Find("Content");

        Debug.LogWarning(transform.name + ": Load Content", gameObject);
    }

    protected virtual void LoadUIInvSpawner()
    {
        if(uiInvSpawner != null) return;

        uiInvSpawner = transform.GetComponentInChildren<UIInvItemSpawner>();

        Debug.LogWarning(transform.name + ": Load UIInvItemSpawner", gameObject);
    }
}