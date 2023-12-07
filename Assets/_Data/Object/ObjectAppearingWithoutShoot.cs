using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectAppearingWithoutShoot : ShootableObjectAbstract, IObjectAppearingObserver
{
    [Header("Appearing Without Shoot")]
    [SerializeField] protected ObjectAppearing objectAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        RegisterAppearingEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadObjectAppearing();
    }

    protected virtual void LoadObjectAppearing() {
        if(objectAppearing != null) return;

        objectAppearing = GetComponent<ObjectAppearing>();

        Debug.Log(transform.name + ": Load ObjectAppearing", gameObject);
    }

    protected virtual void RegisterAppearingEvent() {
        objectAppearing.ObserverAdding(this);
    }

    public void OnAppearingStart()
    {
        shootableObjectCtrl.ObjectShooting.gameObject.SetActive(false);
        shootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearingFinish()
    {
       shootableObjectCtrl.ObjectShooting.gameObject.SetActive(true);
       shootableObjectCtrl.ObjectLookAtTarget.gameObject.SetActive(true);
       shootableObjectCtrl.Spawner.Hold(transform.parent);
    }
}
