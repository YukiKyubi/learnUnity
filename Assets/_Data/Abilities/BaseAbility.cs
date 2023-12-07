using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : HiroMonoBehavior
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;
    [SerializeField] protected float timer = 2;
    [SerializeField] protected float delay = 2;
    [SerializeField] protected bool isReady = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilities();
    }

    protected virtual void LoadAbilities() {
        if(abilities != null) return;

        abilities = transform.parent.GetComponent<Abilities>();

        Debug.Log(transform.name + ": Load Abilities", gameObject);
    }

    protected virtual void FixedUpdate() {
        Timing();
    }

    protected virtual void Update() {
        
    }

    protected virtual void Timing() {
        if(isReady) return;

        timer += Time.fixedDeltaTime;

        if(timer < delay) return;

        isReady = true;
    }

    protected virtual void Active() {
        isReady = false;
        timer = 0;
    }
}
