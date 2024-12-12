using System;
using UnityEngine;
using Zenject;

public class GiveCoins : MonoBehaviour
{
    private LevelsStars levelsStars;
    private EndRoundScript endRoundScript;
    private ExpScript expScript;
    private SaveJson saveJson;
    private PurchaseSystem purchaseSystem;

    private float rewardRatio = 0.34f;
    [HideInInspector] public int valueMoney;

    public event Action AmountChanged;

    [Inject]
    public void Construct(LevelsStars levelsStars, EndRoundScript endRoundScript, ExpScript expScript, SaveJson saveJson, PurchaseSystem purchaseSystem)
    {
        this.levelsStars = levelsStars;
        this.endRoundScript = endRoundScript;
        this.expScript = expScript;
        this.saveJson = saveJson;
        this.purchaseSystem = purchaseSystem;
    }
    private void OnEnable()
    {
        endRoundScript.RoundChanged += OnRoundChanged;
    }

    private void OnDisable()
    {
        endRoundScript.RoundChanged -= OnRoundChanged;
    }

    private void OnRoundChanged()
    {
        int amount = Convert.ToInt32(levelsStars.CalculateStarsForCurrentLevel(expScript.CurrentExp) * rewardRatio * levelsStars.currentLevel);

        if (amount <= 0) amount = 1;

        valueMoney = amount;

        AddMoney(amount);

        AmountChanged?.Invoke();

        saveJson.Save();
        saveJson.Load();

        purchaseSystem.ButtonBlock();    
    }

    public void ChangedAmount()
    {
        AmountChanged?.Invoke();
    }

    public void AddMoney(int value)
    {
        if (value <= 0)
            return;

        valueMoney = value;
        saveJson.MoneyData  += value;        
    }

    public void WasteMoney(int price)
    {
        saveJson.MoneyData -= price;
        ChangedAmount();
        saveJson.Save();
        saveJson.Load();
    }
}
