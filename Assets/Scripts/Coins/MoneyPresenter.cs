using UnityEngine;
using Zenject;

public class MoneyPresenter: MonoBehaviour
{
    private GiveCoins giveCoins;
    private SaveJson saveJson;
    private CoinsView coinsView;

    [Inject]
    public void Construct(GiveCoins giveCoins, CoinsView coinsView, SaveJson saveJson)
    {
        this.giveCoins = giveCoins;
        this.coinsView = coinsView;
        this.saveJson = saveJson;
    }

    public void OnEnable()
    {
        giveCoins.AmountChanged += OnAmountChanged;
    }

    public void OnDisable()
    {
        giveCoins.AmountChanged -= OnAmountChanged;
    }

    private void OnAmountChanged()
    {
        this.coinsView.AmountChanged(saveJson.MoneyData.ToString());
    }
}
