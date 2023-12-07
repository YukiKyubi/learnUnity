using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        MapSetTarget();
    }

    protected virtual void MapSetTarget() {
        if(target != null) return;

        ShipCtrl ship = PlayerCtrl.Instance.ShipCtrl;
        SetTarget(ship.transform);
    }
}
