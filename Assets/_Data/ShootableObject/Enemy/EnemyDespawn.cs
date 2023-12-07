using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValues()
    {
        base.ResetValues();
        disLimit = 20f;
    }
}
