using System;

[Serializable]
public class ItemInventory
{
    public string itemId;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone() 
    {
        ItemInventory item = new ItemInventory() 
        {
            itemId = RandomId(),
            itemProfile = itemProfile,
            itemCount = itemCount,
            upgradeLevel = upgradeLevel
        };

        return item;
    }

    public static string RandomId()
    {
       return RandomStringGenerator.Generate(15);
    }
}
