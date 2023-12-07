using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : HiroMonoBehavior
{
    [SerializeField] protected Spawner spawner;

    public Spawner Spawner { get => spawner; }

    [SerializeField] protected SpawnPoints spawnPoints;

    public SpawnPoints SpawnPoints { get => spawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoints();
    }

    protected virtual void LoadJunkSpawner() {
        if(spawner != null) return;
        spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + " : Load JunkSpawner", gameObject);
    }

    protected virtual void LoadJunkSpawnPoints() {
        if(spawnPoints != null) return;
        spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>();
        Debug.Log(transform.name + " : Load JunkSpawnPoints", gameObject);
    }
}
