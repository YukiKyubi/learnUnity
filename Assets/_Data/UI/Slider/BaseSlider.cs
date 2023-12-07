using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : HiroMonoBehavior
{
    [Header("Slider")]
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        base.Start();
        AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSlider();
    }

    protected virtual void FixedUpdate()
    {
        
    }

    protected virtual void LoadSlider()
    {
        if(slider != null) return;

        slider = GetComponent<Slider>();

        Debug.LogWarning(transform.name + ": Load Slider", gameObject);
    }

    protected virtual void AddOnClickEvent()
    {
        slider.onValueChanged.AddListener(OnChanged);
    }

    protected abstract void OnChanged(float newValue);
}
