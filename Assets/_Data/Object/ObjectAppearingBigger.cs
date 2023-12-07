using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearingBigger : ObjectAppearing
{
    [Header("Object Bigger")]
    [SerializeField] protected float speedScale = 0.01f;
    [SerializeField] protected float currentScale = 0;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1;

    protected override void OnEnable()
    {
        base.OnEnable();
        InitScale();
    }

    protected override void Appearing()
    {
        currentScale += speedScale;
        transform.parent.localScale = new Vector3(currentScale, currentScale, currentScale);

        if(currentScale >= maxScale) 
        {
            transform.parent.localScale = new Vector3(maxScale, maxScale, maxScale);

            Appear();
        }
    }

    protected virtual void InitScale() 
    {
        transform.parent.localScale = Vector3.zero;
        currentScale = startScale;
    }
}
