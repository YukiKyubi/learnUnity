using UnityEngine;
public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;

    public static MotherShipSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();

        if(instance != null) Debug.LogError("Only 1 MotherShipSpawner is allowed to exist");

        instance = this;
    }
}