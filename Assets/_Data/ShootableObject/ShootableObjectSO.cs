using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string objectName = "Shootable Object";
    public ObjectType objectType;
    public int maxHP = 2;
    public List<ItemDropRate> dropList;
}
