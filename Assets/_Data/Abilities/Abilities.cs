using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : HiroMonoBehavior
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjectCtrl abilityObjectCtrl;
    public AbilityObjectCtrl AbilityObjectCtrl => abilityObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAbilityObjectCtrl();
    }

    protected virtual void LoadAbilityObjectCtrl() {
        if(abilityObjectCtrl != null) return;

        abilityObjectCtrl = transform.parent.GetComponent<AbilityObjectCtrl>();

        Debug.Log(transform.name + ": Load AbilityObjectCtrl", gameObject);
    }
}
