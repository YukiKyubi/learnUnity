using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : HiroMonoBehavior
{
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawnerCtrl();
    }

    protected virtual void LoadSpawnerCtrl() {
        if(spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + " : Load JunkSpawnerCrtl", gameObject);
    }

    protected virtual void FixedUpdate() {
        Spawning();
    }

    protected virtual void Spawning() {
        if(ReachRandomLimit()) return;

        randomTimer += Time.fixedDeltaTime;

        if(randomTimer < randomDelay) return;

        randomTimer = 0;

        Transform randPoint = this.spawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = spawnerCtrl.Spawner.RandomPrefab();
        Transform obj = spawnerCtrl.Spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool ReachRandomLimit() {
        int currentSpawnCount = spawnerCtrl.Spawner.SpawnedCount;
        return currentSpawnCount >= randomLimit;
    }
}
