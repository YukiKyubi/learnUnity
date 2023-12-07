using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : HiroMonoBehavior
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.02f;
    [SerializeField] protected float distance = 1;
    [SerializeField] protected float minDis = 1;


    protected virtual void FixedUpdate() {
        this.Moving();
    }

    public virtual void SetSpeed(float speed) {
        this.speed = speed;
    }

    protected virtual void Moving() {
        distance = Vector3.Distance(transform.position, targetPosition);
        if(distance < minDis) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
