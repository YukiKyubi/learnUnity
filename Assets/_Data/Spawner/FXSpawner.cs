using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    public static FXSpawner instance;

    public static FXSpawner Instance => instance;

    public static string smokeOne = "Smoke_1";
    public static string impactOne = "Impact_1";

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 FXSpawner is allowed to exist");
        instance = this;
    }
}
