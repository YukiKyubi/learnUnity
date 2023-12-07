using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : HiroMonoBehavior
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 9;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadJunkSpawnerCtrl();
    }

    protected virtual void LoadJunkSpawnerCtrl() {
        if(junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " : Load JunkSpawnerCrtl", gameObject);
    }

    protected virtual void FixedUpdate() {
        JunkSpawning();
    }

    protected virtual void JunkSpawning() {
        if(ReachRandomLimit()) return;

        randomTimer += Time.fixedDeltaTime;

        if(randomTimer < randomDelay) return;

        randomTimer = 0;

        Transform randPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool ReachRandomLimit() {
        int currentSpawnCount = junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentSpawnCount >= randomLimit;
    }
}
