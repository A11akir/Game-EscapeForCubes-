using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveJson
{
    private GiveCoins giveCoins;
    private StoredData storedData;
    private HideLevelsView hideLevelsView;
    private ChangeSkin changeSkin;

    public int SkinPlayerData;
    public int MoneyData;
    public List<int> levelsStarsViewData;
    public List<int> ByItemListData = new List<int>();

    public SaveJson(GiveCoins giveCoins, StoredData storedData, HideLevelsView hideLevelsView, ChangeSkin changeSkin)
    {
        this.giveCoins = giveCoins;
        this.storedData = storedData;
        this.hideLevelsView = hideLevelsView;
        this.changeSkin = changeSkin;
    }

    public void Save()
    {
        StoredData data = new StoredData();

        if (ByItemListData.Count != 0)
        {
            data.ByItemList = ByItemListData;
        }
        data.SkinPlayer = SkinPlayerData;
        data.Money = MoneyData;
        data.levelsStarsView = storedData.levelsStarsView;

        File.WriteAllText(Application.dataPath + "/StoredDataFile.json",
            JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            }));
    }

    public void Load()
    {
        StoredData data = JsonConvert.DeserializeObject<StoredData>(File.ReadAllText(Application.dataPath + "/StoredDataFile.json"));

        if (ByItemListData.Count != 0)
        {
            ByItemListData = data.ByItemList;
        }
        storedData.ByItemList = data.ByItemList;
     
        SkinPlayerData = data.SkinPlayer;
        storedData.SkinPlayer = data.SkinPlayer;

        MoneyData = data.Money;
        storedData.Money = data.Money;

        levelsStarsViewData = data.levelsStarsView;
        storedData.levelsStarsView = data.levelsStarsView;

        giveCoins.ChangedAmount();
        hideLevelsView.ViewStars();
        changeSkin.SkinLoad();
    }
}
