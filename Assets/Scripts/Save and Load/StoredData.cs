
using System.Collections.Generic;


[System.Serializable]
public class StoredData
{
    public int SkinPlayer = 0;

    private int money = 0;
    public int Money
    {
        get => money;
        set
        {
            money = (value >= 0) ? value : 0;
        }
    }

    public List<int> ByItemList = new List<int>();

    public List<int> levelsStarsView = new List<int> (100);

    public void SetBestStarsForLevel(int currentLevel, int stars)
    {
        while (levelsStarsView.Count <= currentLevel)
        {
            levelsStarsView.Add(0);
        }

        levelsStarsView[currentLevel] = stars;
    }
}


