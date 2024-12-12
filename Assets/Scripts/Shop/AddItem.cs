
public class AddItem
{
    private PurchaseSystem purchaseSystem;
    private LevelConfigSpawner levelConfigSpawner;
    private SpawnerObjectTag spawnerObjectTag;
    private GiveCoins giveCoins;
    private StoredData storedData;
    private SaveJson saveJson;

    public AddItem(PurchaseSystem purchaseSystem, LevelConfigSpawner levelConfigSpawner, SpawnerObjectTag spawnerObjectTag, GiveCoins giveCoins, StoredData storedData, SaveJson saveJson)
    {
        this.purchaseSystem = purchaseSystem;
        this.levelConfigSpawner = levelConfigSpawner;
        this.spawnerObjectTag = spawnerObjectTag;
        this.giveCoins = giveCoins;
        this.storedData = storedData;
        this.saveJson = saveJson;
    }

    public void ItemBy(int number)
    {
        ItemSelect(number);

        giveCoins.WasteMoney(purchaseSystem.priceItem);
    }

    public void ItemLoad()
    {   
        for (int i = 0; storedData.ByItemList.Count > i; i++)
        {
            spawnerObjectTag.objectTags.Add(levelConfigSpawner.objectTagsAll[storedData.ByItemList[i]]);
        }
        
        storedData.ByItemList.Clear();
        saveJson.ByItemListData.Clear();
        saveJson.Save();
    }

    private void ItemSelect(int number)
    {
        switch (number)
        {
            case 1:
                levelConfigSpawner.ByItemAddSpawner(ObjectTagEnum.ItemTimePlus);
                break;
            case 2:
                levelConfigSpawner.ByItemAddSpawner(ObjectTagEnum.ItemSpeedPlus);
                break;
        }
    }
}
