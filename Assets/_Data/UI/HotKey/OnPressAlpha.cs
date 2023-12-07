using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressAlpha : UIHotKeyAbstract
{
    void Update()
    {
        CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if(InputHotKeyManager.Instance.isAlpha1) Press(0);
        if(InputHotKeyManager.Instance.isAlpha2) Press(1);
        if(InputHotKeyManager.Instance.isAlpha3) Press(2);
        if(InputHotKeyManager.Instance.isAlpha4) Press(3);
        if(InputHotKeyManager.Instance.isAlpha5) Press(4);
        if(InputHotKeyManager.Instance.isAlpha6) Press(5);
        if(InputHotKeyManager.Instance.isAlpha7) Press(6);
    }

    protected virtual void Press(int alpha)
    {
        ItemSLot itemSLot = hotKeyCtrl.itemSLots[alpha];
        Pressable pressable = itemSLot.GetComponentInChildren<Pressable>();

        if(pressable == null) return;
        pressable.Pressed();
    }
}
