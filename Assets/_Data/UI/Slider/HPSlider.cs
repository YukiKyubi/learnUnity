using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSlider : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float maxHP = 1;
    [SerializeField] protected float currentHP = 1;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = currentHP / maxHP;
        slider.value = hpPercent;
    }

    protected override void OnChanged(float newValue)
    {
        
    }

    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }

    public virtual void SetCurrentHP(float currentHP)
    {
        this.currentHP = currentHP;
    }
}
