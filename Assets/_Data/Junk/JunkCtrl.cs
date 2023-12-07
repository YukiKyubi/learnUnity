using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : HiroMonoBehavior
{
    [SerializeField] protected Transform model;

    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;

    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected ShootableObjectSO shootableObject;

    public ShootableObjectSO ShootableObject => shootableObject;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
        LoadJunkSO();
    }

    protected virtual void LoadModel() {
        if(model != null) return;
        model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }

    protected virtual void LoadJunkDespawn() {
        if(junkDespawn != null) return;
        junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": Load JunkDespawn", gameObject);
    }

    protected virtual void LoadJunkSO() {
        if(shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name;
        shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log(transform.name + ": Load JunkSO" + resPath, gameObject);
    }
}
