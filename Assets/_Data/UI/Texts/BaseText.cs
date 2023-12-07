using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : HiroMonoBehavior
{
    [Header("Text")]
    [SerializeField] protected TextMeshProUGUI textMeshPro;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro()
    {
        if(textMeshPro != null) return;

        textMeshPro = GetComponent<TextMeshProUGUI>();

        Debug.LogWarning(transform.name + ": Load TextMeshPro", gameObject);
    }
}
