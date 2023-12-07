using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ObjectMovement
{
    [SerializeField] protected Transform target;

    protected override void FixedUpdate()
    {
        GetTargetPosition();
        base.FixedUpdate();
    }

    public virtual void SetTarget(Transform target) {
        this.target = target;
    }

    protected virtual void GetTargetPosition() {
        targetPosition = target.position;
        targetPosition.z = 0;
    }
}
