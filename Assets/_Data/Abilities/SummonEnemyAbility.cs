using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemyAbility : SummonAbility
{
    [Header("Summon Enemy")]
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 2;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ClearDeadMinion();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner() {
        if(spawner != null) return;

        GameObject spawnerObject = GameObject.Find("EnemySpawner");
        spawner = spawnerObject.GetComponent<EnemySpawner>();

        Debug.Log(transform.name + ": Load EnemySpawner", gameObject);
    }

    protected override void Summoning()
    {
        if(minions.Count >= minionLimit) return;
        base.Summoning();
    }

    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = abilities.AbilityObjectCtrl.transform;

        minions.Add(minion);

        return minion;
    }

    protected virtual void ClearDeadMinion() 
    {
        foreach(Transform minion in minions) 
        {
            if(minion.gameObject.activeSelf == false) 
            {
                minions.Remove(minion);
                return;
            }
        }
    }
}
