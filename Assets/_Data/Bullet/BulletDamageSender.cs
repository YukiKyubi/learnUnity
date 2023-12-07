using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl() {
        if(bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": Load BulletCtrl", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        DestroyBullet();
    }

    protected virtual void DestroyBullet() {
        bulletCtrl.BulletDespawn.DespawnObject();
    }
}
