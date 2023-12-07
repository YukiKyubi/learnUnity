using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float delay = 2;
    [SerializeField] protected float timer = 0;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetTimer();
    }

    protected virtual void ResetTimer() {
        timer = 0;
    }

    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        if(timer > delay) return true;
        return false;
    }
}
