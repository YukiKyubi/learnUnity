using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInvClose : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
