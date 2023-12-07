using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;

    public JunkCtrl JunkCtrl { get => junkCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl() {
        if(junkCtrl != null) return;
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": Load JunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        OnDeadFX();
        OnDeadDrop();
        junkCtrl.JunkDespawn.DespawnObject();
    }

    protected virtual void OnDeadDrop() {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        ItemDropSpawner.Instance.Drop(junkCtrl.ShootableObject.dropList, pos, rot);
    }

    protected virtual void OnDeadFX() {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName() {
        return FXSpawner.smokeOne;
    }

    protected override void Reborn()
    {
        maxHP = junkCtrl.ShootableObject.maxHP;
        base.Reborn();
    }
}
