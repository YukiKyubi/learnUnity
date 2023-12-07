using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShipHp : BaseText
{
    protected virtual void FixedUpdate()
    {
        UpdateShipHP();
    }

    protected virtual void UpdateShipHP()
    {
        int maxHp = PlayerCtrl.Instance.ShipCtrl.DamageReceiver.MaxHP;
        int hp = PlayerCtrl.Instance.ShipCtrl.DamageReceiver.Hp;

        textMeshPro.SetText(hp + " / " + maxHp);
    }
}
