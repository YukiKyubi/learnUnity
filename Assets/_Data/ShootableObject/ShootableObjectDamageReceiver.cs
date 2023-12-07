using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCtrl();
    }

    protected virtual void LoadCtrl() {
        if(shootableObjectCtrl != null) return;

        shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();

        Debug.Log(transform.name + ": Load Ctrl", gameObject);
    }

    protected override void OnDead()
    {
        OnDeadFX();
        OnDeadDrop();
        shootableObjectCtrl.Despawn.DespawnObject();
    }

    protected virtual void OnDeadDrop() {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        ItemDropSpawner.Instance.Drop(shootableObjectCtrl.ShootableObject.dropList, pos, rot);
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
        maxHP = shootableObjectCtrl.ShootableObject.maxHP;
        base.Reborn();
    }
}
