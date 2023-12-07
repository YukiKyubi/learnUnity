using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipModify : ObjectModifyAbstract
{
    [Header("Mother Ship Modify")]
    [SerializeField] protected float speed = 0.005f;

    [SerializeField] protected float rotSpeed = 0.01f;

    protected override void Start()
    {
        base.Start();
        ShipModify();
    }

    protected virtual void ShipModify() {
        shootableObjectCtrl.ObjectMovement.SetSpeed(speed);
        shootableObjectCtrl.ObjectLookAtTarget.SetRotSpeed(rotSpeed);
    }
}
