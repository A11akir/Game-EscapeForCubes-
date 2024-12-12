using TMPro;
using UnityEngine;
using Zenject;

public class PurchaseSystemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] skinsCostText;
    [SerializeField] private TextMeshProUGUI[] itemCostText;

    [Inject] private PurchaseSystem purchaseSystem;

    private void Start()
    {
        for (int i = 0; i < purchaseSystem.prices.Count; i++)
        {
            skinsCostText[i].text = purchaseSystem.prices[i].ToString();
        }

        for (int i = 0; i < itemCostText.Length; i++)
        {
            itemCostText[i].text = purchaseSystem.priceItem.ToString();
        }        
    }
}
