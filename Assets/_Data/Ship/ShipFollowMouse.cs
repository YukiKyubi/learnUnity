using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ObjectMovement
{
    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }

    protected virtual void GetMousePosition() {
        targetPosition = InputManager.Instance.MouseWorldPos;
        targetPosition.z = 0;
    }
}
