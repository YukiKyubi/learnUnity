using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HPBar : HiroMonoBehavior
{
    [Header("HP")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected HPSlider hpSlider;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate() 
    {
        HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHPSlider();
        LoadFollowTarget();
        LoadSpawner();
    }

    protected virtual void LoadHPSlider()
    {
        if(hpSlider != null) return;

        hpSlider = GetComponentInChildren<HPSlider>();
        
        Debug.LogWarning(transform.name + ": Load HPSlider", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if(followTarget != null) return;

        followTarget = GetComponent<FollowTarget>();

        Debug.LogWarning(transform.name + ": Load FollowTarget", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if(spawner != null) return;

        spawner = transform.parent.parent.GetComponent<Spawner>();

        Debug.LogWarning(transform.name + ": Load Spawner", gameObject);
    }

    protected virtual void HPShowing()
    {
        if(shootableObjectCtrl == null) return;

        bool isDead = shootableObjectCtrl.DamageReceiver.IsDead();

        if(isDead) spawner.Despawn(transform);

        float hp = shootableObjectCtrl.DamageReceiver.Hp;
        float maxHP = shootableObjectCtrl.DamageReceiver.MaxHP;

        hpSlider.SetCurrentHP(hp);
        hpSlider.SetMaxHP(maxHP);
    }

    public virtual void SetShootableObject(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }

    public virtual void SetFollowTarget(Transform target)
    {
        followTarget.SetTarget(target);
    }
}
