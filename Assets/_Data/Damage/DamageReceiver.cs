using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : HiroMonoBehavior
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;

    public int Hp => hp;

    [SerializeField] protected int maxHP = 2;

    public int MaxHP => maxHP;
    
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        Reborn();
    }

    protected override void ResetValues()
    {
        base.ResetValues();
        Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
    }

    protected virtual void LoadCollider() {
        if(sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.4f;
        Debug.Log(transform.name + ": Load Sphere Collider", gameObject);
    }

    protected virtual void Reborn() {
        hp = maxHP;
        isDead = false;
    }

    public virtual void Add(int add) {
        if(isDead) return;

        hp += add;
        if(hp > maxHP) hp = maxHP;
    }

    public virtual void Deduct(int deduct) {
        if(isDead) return;

        hp -= deduct;
        if(hp < 0) hp = 0;
        CheckIsDead();
    }

    public virtual bool IsDead() {
        return hp <= 0;
    }

    protected virtual void CheckIsDead() {
        if(!IsDead()) return;
        isDead = true;
        OnDead();
    }

    protected abstract void OnDead();
}
