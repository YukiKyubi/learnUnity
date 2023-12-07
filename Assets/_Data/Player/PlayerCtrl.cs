using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : HiroMonoBehavior
{
    private static PlayerCtrl instance;

    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl shipCtrl;

    public ShipCtrl ShipCtrl => shipCtrl;

    [SerializeField] protected PlayerPickup playerPickup;

    public PlayerPickup PlayerPickup => playerPickup;

    [SerializeField] protected PlayerAbility playerAbility;

    public PlayerAbility PlayerAbility => playerAbility;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 PlayerCtrl is allowed to exist");
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerPickup();
        LoadPlayerAbility();
    }

    protected virtual void LoadPlayerPickup() {
        if(playerPickup != null) return;

        playerPickup = transform.GetComponentInChildren<PlayerPickup>();

        Debug.Log(transform.name + ": Load PlayerPickup", gameObject);
    }

    protected virtual void LoadPlayerAbility()
    {
        if(playerAbility != null) return;

        playerAbility = transform.GetComponentInChildren<PlayerAbility>();

        Debug.Log(transform.name + ": Load PlayerAbility", gameObject);
    }
}
