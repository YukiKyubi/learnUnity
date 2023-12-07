using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : HiroMonoBehavior
{
    [Header("Button")]
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadButton();
    }

    protected virtual void LoadButton()
    {
        if(button != null) return;

        button = GetComponent<Button>();

        Debug.Log(transform.name + ": Load Button", gameObject);
    }

    protected virtual void AddOnClickEvent()
    {
        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick();
}
