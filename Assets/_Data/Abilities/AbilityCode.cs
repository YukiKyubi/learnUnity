using System;
using UnityEngine;

public enum AbilityCode
{
    NoAbility = 0,
    Laser = 1,
    Missile = 2
}

public class AbilityParser
{
    public static AbilityCode FromString(string name)
    {
        try
        {
            return (AbilityCode)Enum.Parse(typeof(AbilityCode), name);
        }
        catch(ArgumentException e)
        {
            Debug.Log(e.ToString());
            return AbilityCode.NoAbility;
        }
    }
}
