using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiroMonoBehavior : MonoBehaviour
{
    protected virtual void Start() {
        
    }
    protected virtual void Reset() {
        this.LoadComponents();
        this.ResetValues();
    }

    protected virtual void Awake() {
        this.LoadComponents();
    }

    protected virtual void LoadComponents() {

    }

    protected virtual void ResetValues() {
        
    }

    protected virtual void OnEnable() {
        
    }

    protected virtual void OnDisable() {
        
    }
}
