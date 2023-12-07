using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtMouse : ObjectLookAtTarget
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
