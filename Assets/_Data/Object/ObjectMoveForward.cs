using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveForward : ObjectMovement
{
    [SerializeField] protected Transform target;

    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMoveTarget();
    }

    protected virtual void LoadMoveTarget() {
        if(target != null) return;

        target = transform.Find("MoveTarget");

        Debug.Log(transform.name + ": Load MoveTarget", gameObject);
    }

    protected virtual void GetMousePosition() {
        targetPosition = target.position;
        targetPosition.z = 0;
    }
}
