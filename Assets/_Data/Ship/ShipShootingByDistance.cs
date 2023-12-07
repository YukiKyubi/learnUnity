using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingByDistance : ObjectShooting
{
    [Header("Shoot By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3;

    public virtual void SetTarget(Transform target) {
        this.target = target;
    }

    protected override bool IsShooting()
    {
        distance = Vector3.Distance(transform.position, target.position);
        isShooting = distance < shootDistance;

        return isShooting;
    }
}
