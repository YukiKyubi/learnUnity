using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilityCode ability;

    public override void Pressed()
    {
        PlayerCtrl.Instance.PlayerAbility.Active(ability);
    }
}
