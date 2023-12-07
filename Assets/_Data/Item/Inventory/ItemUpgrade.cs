using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgarde : InventoryAbstract
{
    [SerializeField] protected int maxLevel = 9;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 2);
    }

    protected virtual void Test() {
        UpgradeItem(0);
    }

    public virtual bool UpgradeItem(int itemIndex) {
        if(itemIndex >= inventory.Items.Count) return false;

        ItemInventory itemInventory = inventory.Items[itemIndex];

        if(itemInventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;

        if(!IsUpgradable(upgradeLevels)) return false;
        if(!HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;

        DeductIngredients(upgradeLevels, itemInventory.upgradeLevel);

        itemInventory.upgradeLevel++;

        return true;
    }

    protected virtual bool IsUpgradable(List<ItemRecipe> upgradeLevels) {
        if(upgradeLevels.Count == 0) return false;

        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel) {
        ItemCode itemCode;
        int itemCount;

        if(currentLevel >= upgradeLevels.Count) {
            Debug.LogError("Item can't be upgraded anymore, current" + currentLevel);

            return false;
        }

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];

        foreach(ItemRecipeIngredients ingredient in currentRecipeLevel.ingredients) {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            if(!inventory.ItemCheck(itemCode, itemCount)) return false;
        }

        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel) {
        ItemCode itemCode;
        int itemCount;
        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];

        foreach(ItemRecipeIngredients ingredient in currentRecipeLevel.ingredients) {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            inventory.DeductItems(itemCode, itemCount);
        }
    }
}
