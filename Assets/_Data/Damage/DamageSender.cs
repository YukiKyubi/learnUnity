using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : HiroMonoBehavior
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj) {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if(damageReceiver == null) return;
        Send(damageReceiver);
        CreateFXImpact();
    }

    public virtual void Send(DamageReceiver damageReceiver) {
        damageReceiver.Deduct(damage);
    }

    protected virtual void CreateFXImpact() {

        string fxName = GetFXImpactName();
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetFXImpactName() {
        return FXSpawner.impactOne;
    }
}
