using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    // Start is called before the first frame update
    public override void DespawnObject() {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
