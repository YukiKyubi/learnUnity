using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : HiroMonoBehavior, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Transform realParent;

    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadImage();
    }

    protected virtual void LoadImage()
    {
        if(image != null) return;

        image = GetComponent<Image>();

        Debug.LogWarning(transform.name + ": Load Image", gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        realParent = transform.parent;
        transform.SetParent(UIHotKeyCtrl.Instance.transform);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(realParent);
        image.raycastTarget = true;
    }
}
