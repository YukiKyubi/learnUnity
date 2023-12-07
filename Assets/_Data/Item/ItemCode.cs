using System;
using UnityEngine;

public enum ItemCode {
    NoItem = 0,
    IronOre = 1,
    GoldOre = 2, 
    CopperSword = 3
}

public class ItemCodeParser {
    public static ItemCode FromString(string itemName) {
        try {
            return (ItemCode)Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException e) {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
}
