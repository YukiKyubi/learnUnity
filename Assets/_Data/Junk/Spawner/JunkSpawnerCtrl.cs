using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : HiroMonoBehavior
{
    [SerializeField] protected JunkSpawner junkSpawner;

    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected SpawnPoints spawnPoints;

    public SpawnPoints SpawnPoints { get => spawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoints();
    }

    protected virtual void LoadJunkSpawner() {
        if(junkSpawner != null) return;
        junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + " : Load JunkSpawner", gameObject);
    }

    protected virtual void LoadJunkSpawnPoints() {
        if(spawnPoints != null) return;
        spawnPoints = FindObjectOfType<SpawnPoints>();
        Debug.Log(transform.name + " : Load JunkSpawnPoints", gameObject);
    }
}
