using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : HiroMonoBehavior
{
    [Header("Object Appearing")]
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObjectAppearingObserver> observers = new List<IObjectAppearingObserver>();

    public bool IsAppearing => isAppearing;

    public bool Appeared => appeared;

    protected override void Start()
    {
        base.Start();
        OnAppearStart();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        appeared = false;
        OnAppearStart();
    }

    protected virtual void FixedUpdate() {
        Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear() {
        appeared = true;
        isAppearing = false;
        OnAppearFinish();
    }

    public virtual void ObserverAdding(IObjectAppearingObserver observer) {
        observers.Add(observer);
    }

    protected virtual void OnAppearStart() {
        foreach(IObjectAppearingObserver observer in observers) {
            observer.OnAppearingStart();
        }
    }

    protected virtual void OnAppearFinish() {
        foreach(IObjectAppearingObserver observer in observers) {
            observer.OnAppearingFinish();
        }
    }
}
