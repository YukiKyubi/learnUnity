using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class ShootableObjectCtrl : HiroMonoBehavior
{
    [SerializeField] protected Transform model;

    public Transform Model => model;

    [SerializeField] protected Despawn despawn;

    public Despawn Despawn => despawn;

    [SerializeField] protected ShootableObjectSO shootableObject;

    public ShootableObjectSO ShootableObject => shootableObject;

    [SerializeField] protected ObjectShooting objectShooting;

    public ObjectShooting ObjectShooting => objectShooting;

    [SerializeField] protected ObjectMovement objectMovement;

    public ObjectMovement ObjectMovement => objectMovement;

    [SerializeField] protected ObjectLookAtTarget objectLookAtTarget;

    public ObjectLookAtTarget ObjectLookAtTarget => objectLookAtTarget;

    [SerializeField] protected Spawner spawner;

    public Spawner Spawner => spawner;

    [SerializeField] protected DamageReceiver damageReceiver;

    public DamageReceiver DamageReceiver => damageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadDespawn();
        LoadSO();
        LoadObjectShooting();
        LoadObjectMovement();
        LoadObjectLookAtTarget();
        LoadSpawner();
        LoadDamageReceiver();
    }

    protected virtual void LoadModel() {
        if(model != null) return;

        model = transform.Find("Model");

        Debug.Log(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadDespawn() {
        if(despawn != null) return;

        despawn = transform.GetComponentInChildren<Despawn>();

        Debug.Log(transform.name + ": Load Despawn", gameObject);
    }

    protected virtual void LoadSO() {
        if(shootableObject != null) return;

        string path = "ShootableObject/" + GetObjectTypeString() + "/" + transform.name;
        shootableObject = Resources.Load<ShootableObjectSO>(path);

        Debug.Log(transform.name + ": Load SO", gameObject);
    }

    protected virtual void LoadObjectShooting() {
        if(objectShooting != null) return;

        objectShooting = transform.GetComponentInChildren<ObjectShooting>();

        Debug.Log(transform.name + ": Load ObjectShooting", gameObject);
    }

    protected virtual void LoadObjectMovement() {
        if(objectMovement != null) return;

        objectMovement = GetComponentInChildren<ObjectMovement>();

        Debug.Log(transform.name + ": Load ObjectMovement", gameObject);
    }

    protected virtual void LoadObjectLookAtTarget() {
        if(objectLookAtTarget != null) return;

        objectLookAtTarget = GetComponentInChildren<ObjectLookAtTarget>();

        Debug.Log(transform.name + ": Load ObjectLookAtTarget", gameObject);
    }

    protected virtual void LoadSpawner() {
        if(spawner != null) return;

        spawner = transform.parent?.parent?.GetComponent<Spawner>();

        Debug.Log(transform.name + ": Load Spawner", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if(damageReceiver != null) return;

        damageReceiver = GetComponentInChildren<DamageReceiver>();

        Debug.Log(transform.name + ": Load DamageReceiver", gameObject);
    }

    protected abstract string GetObjectTypeString();
}
