using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtPlayer : ObjectLookAtTarget
{
    [SerializeField] protected GameObject player;

    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected virtual void LoadPlayer() {
        if(player != null) return;

        player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log(transform.name + ": Load Player", gameObject);
    }

    protected virtual void GetMousePosition() {
        if(player == null) return;

        targetPosition = InputManager.Instance.MouseWorldPos;
        targetPosition.z = 0;
    }
}
