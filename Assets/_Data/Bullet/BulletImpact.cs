using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider();
        LoadRigibody();
    }

    protected virtual void LoadCollider() {
        if(sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": Load SphereCollider", gameObject);
    }

    protected virtual void LoadRigibody() {
        if(_rigidbody != null) return;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": Load Rigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider) {
        if (collider.transform.parent == bulletCtrl.Shooter) return;

        bulletCtrl.DamageSender.Send(collider.transform);
        //CreateFXImpact(collider);
    }

    // protected virtual void CreateFXImpact(Collider collider) {
    //     if(collider.transform.parent == bulletCtrl.Shooter) return;

    //     string fxName = GetFXImpactName();
    //     Transform fxImpact = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
    //     fxImpact.gameObject.SetActive(true);
    // }

    // protected virtual string GetFXImpactName() {
    //     return FXSpawner.impactOne;
    // }
}
