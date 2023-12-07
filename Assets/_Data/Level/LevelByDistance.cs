using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("Level By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float distancePerLevel = 10;

    protected virtual void FixedUpdate() {
        Leveling();
    }

    public virtual void SetTarget(Transform target) {
        this.target = target;
    }

    protected virtual void Leveling() {
        if(target == null) return;

        distance = Vector3.Distance(transform.position, target.position);
        int newLevel = GetLevelByDis();

        LevelSet(newLevel);
    }

    protected virtual int GetLevelByDis() {
        return Mathf.FloorToInt(distance / distancePerLevel) + 1;
    }
}
