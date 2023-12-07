using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpAbilityFromInput : WarpAbility
{
    protected override void Update()
    {
        base.Update();
        UpdateKeyDirection();
    }

    protected virtual void UpdateKeyDirection() {
        keyDirection = InputManager.Instance.Direction;
    }
}
