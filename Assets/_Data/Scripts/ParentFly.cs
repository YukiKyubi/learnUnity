using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : HiroMonoBehavior
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
