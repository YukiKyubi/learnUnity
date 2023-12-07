using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public abstract class Spawner : HiroMonoBehavior
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObjs;

    [SerializeField] protected int spawnedCount = 0;

    public int SpawnedCount => spawnedCount;

    protected override void LoadComponents() {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadPrefabs() {
        if(this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
            this.prefabs.Add(prefab);

        this.HidePrefabs();

        Debug.Log(transform.name + ": Load Prefabs", gameObject);
    }

    protected virtual void LoadHolder() {
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": Load Holder", gameObject);
    }

    protected virtual void HidePrefabs() {
        foreach(Transform prefab in prefabs)
            prefab.gameObject.SetActive(false);
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation) {
        Transform prefab = this.GetPrefabByName(prefabName);

        if(prefab == null) {
            Debug.LogWarning("Cannot find prefab " + prefabName);
            return null;
        }
        
        return Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation) {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.SetParent(this.holder);
        spawnedCount++;

        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab) {
        foreach(Transform poolObj in this.poolObjs) {
            if(poolObj.name == prefab.name) {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName) {
        foreach(Transform prefab in this.prefabs) {
            if(prefab.name == prefabName) {
                return prefab;
            }
        }
        return null;
    }

    public virtual void Despawn(Transform obj) {
        if(poolObjs.Contains(obj)) return;
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        spawnedCount--;
    }

    public virtual Transform RandomPrefab() {
        int rand = Random.Range(0, prefabs.Count);
        return prefabs[rand];
    }

    public virtual void Hold(Transform obj) {
        obj.parent = holder;
    }
}
