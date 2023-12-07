using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class ObjectShooting : HiroMonoBehavior
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;

    protected virtual void Update()
    {
        this.IsShooting();
    }

    protected virtual void FixedUpdate() {
        this.Shooting();
    }

    protected virtual void Shooting() {
        if(!this.isShooting) return;
        this.shootTimer += Time.fixedDeltaTime;
        if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        
        if(newBullet == null) return;

        newBullet.gameObject.SetActive(true);

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }

    protected abstract bool IsShooting();
}
