using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : HiroMonoBehavior
{
    [SerializeField] protected DamageSender damageSender;

    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected BulletDespawn bulletDespawn;

    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    [SerializeField] protected Transform shooter;

    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamageSender();
        LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender() {
        if(damageSender != null) return;
        damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": Load DamageSender", gameObject);
    }

    protected virtual void LoadBulletDespawn() {
        if(bulletDespawn != null) return;
        bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": Load BulletDespawn", gameObject);
    }

    public virtual void SetShooter(Transform shooter) {
        this.shooter = shooter;
    }
}
