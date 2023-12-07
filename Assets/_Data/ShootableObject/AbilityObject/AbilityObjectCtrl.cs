using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityObjectCtrl : ShootableObjectCtrl
{
    [Header("Ability Object")]
    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints() {
        if(spawnPoints != null) return;

        spawnPoints = GetComponentInChildren<SpawnPoints>();

        Debug.Log(transform.name + ": Load SpawnPoints", gameObject);
    }
}
