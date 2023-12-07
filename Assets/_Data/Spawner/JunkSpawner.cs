using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;

    public static JunkSpawner Instance { get => instance; }

    public static string meteorOne = "FireMeteor";

    protected override void Awake()
    {
        base.Awake();
        if(JunkSpawner.instance != null) Debug.LogError("Only 1 Fire Meteor is allowed to exist");
        JunkSpawner.instance = this;
    }
}
