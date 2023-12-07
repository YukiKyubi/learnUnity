using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();

        if(instance != null) Debug.LogError("Only 1 EnemySpawner is allowed to exist");

        instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation) 
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);

        addHP2Obj(newEnemy);

        return newEnemy;
    }

    protected virtual void addHP2Obj(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();

        hpBar.SetShootableObject(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);
        hpBar.gameObject.SetActive(true);
    }
}
