using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }
}
