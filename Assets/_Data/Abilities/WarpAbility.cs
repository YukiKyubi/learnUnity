using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpAbility : BaseAbility
{
    [Header("Warp Ability")]
    [SerializeField] protected Spawner spawner;
    protected Vector4 keyDirection;
    [SerializeField] protected bool isWarping = false;
    [SerializeField] protected Vector4 warpDirection;
    [SerializeField] protected float warpDistance = 2;
    [SerializeField] protected float warpSpeed = 1;

    protected override void Update()
    {
        base.Update();
        CheckWarpDirection();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Warping();
    }

    protected virtual void CheckWarpDirection() 
    {
        if(!isReady) return;
        if(isWarping) return;

        if(keyDirection.x == 1) WarpLeft();
        if(keyDirection.y == 1) WarpRight();
        if(keyDirection.z == 1) WarpUp();
        if(keyDirection.w == 1) WarpDown();
    }

    protected virtual void WarpLeft()
    {
        Debug.Log("Warp Left");

        warpDirection.x = 1;
    }

    protected virtual void WarpRight()
    {
        Debug.Log("Warp Right");

        warpDirection.y = 1;
    }
    protected virtual void WarpUp()
    {
        Debug.Log("Warp Up");

        warpDirection.z = 1;
    }
    protected virtual void WarpDown()
    {
        Debug.Log("Warp Down");

        warpDirection.w = 1;
    }

    protected virtual void Warping() 
    {
        if(isWarping) return;
        if(isDirectionNotSet()) return;

        Debug.LogWarning("Warping");
        Debug.LogWarning(warpDirection);

        isWarping = true;

        Invoke(nameof(WarpFinish), warpSpeed);
    }

    protected virtual bool isDirectionNotSet()
    {
        return warpDirection.x == 0 && warpDirection.y == 0
            && warpDirection.z == 0 && warpDirection.w == 0;
    }

    protected virtual void WarpFinish()
    {
        MoveObj();
        warpDirection.Set(0, 0, 0, 0);

        isWarping = false;
        
        Active();
    }

    protected virtual void MoveObj()
    {
        Transform obj = abilities.AbilityObjectCtrl.transform;
        Vector3 newPos = obj.position;

        if(warpDirection.x == 1) newPos.x -= warpDistance;
        if(warpDirection.y == 1) newPos.x += warpDistance;
        if(warpDirection.z == 1) newPos.y += warpDistance;
        if(warpDirection.w == 1) newPos.y -= warpDistance;

        Quaternion fxRot = GetFXQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.impactOne, obj.position, fxRot);
        
        fx.gameObject.SetActive(true);
        
        obj.position = newPos;
    }

    protected virtual Quaternion GetFXQuaternion() 
    {
        Vector3 vector = new Vector3();

        if(warpDirection.x == 1) vector.z = 0;
        if(warpDirection.y == 1) vector.z = 180;
        if(warpDirection.z == 1) vector.z = -90;
        if(warpDirection.w == 1) vector.z = 90;

        if (warpDirection.x == 1 && warpDirection.w == 1) vector.z = 45;
        if (warpDirection.y == 1 && warpDirection.w == 1) vector.z = 135;
        if (warpDirection.x == 1 && warpDirection.z == 1) vector.z = -45;
        if (warpDirection.y == 1 && warpDirection.z == 1) vector.z = -135;

        return Quaternion.Euler(vector);
    }
}
