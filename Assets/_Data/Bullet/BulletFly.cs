using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ParentFly
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.moveSpeed = 8;
    }
}
