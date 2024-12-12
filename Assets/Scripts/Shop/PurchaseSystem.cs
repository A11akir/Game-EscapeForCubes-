using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PurchaseSystem : MonoBehaviour
{
    private GiveCoins giveCoins;
    private SaveJson saveJson;

    [Inject]
    public void Construct(GiveCoins giveCoins, SaveJson saveJson)
    {
        this.giveCoins = giveCoins;
        this.saveJson = saveJson;
    }

    [SerializeField] private GameObject[] gameObjectsSkin;
    [SerializeField] private GameObject[] gameObjectsSkinImage;
    [SerializeField] private GameObject[] gameObjectsItem;
    [SerializeField] private GameObject[] gameObjectsItemImage;

    public List<int> prices = new List<int> ();

    public int priceItem;
    public bool isBought = false;

    private void Awake()
    {
        prices = new List<int> () { 100 };
        priceItem = 10;
    }
    private void OnEnable()
    {       
        giveCoins.AmountChanged += ButtonBlock;
    }

    private void OnDisable()
    {
        giveCoins.AmountChanged -= ButtonBlock;
    }

    public void ButtonBlock()
    {
        for (int i = 0; i < prices.Count; i++)
        {
            if (isBought == false)
            {
                if (saveJson.MoneyData >= prices[i])
                {
                    gameObjectsSkin[i].SetActive(false);
                    gameObjectsSkinImage[i].SetActive(false);
                }
                else
                {
                    gameObjectsSkin[i].SetActive(true);
                    gameObjectsSkinImage[i].SetActive(true);
                }
            }
            if (isBought == true)
            {
                gameObjectsSkin[i].SetActive(false);
                gameObjectsSkinImage[i].SetActive(false);
            }
                     
        }
        
        for (int i = 0;i < gameObjectsItem.Length; i++)
        {
            if (saveJson.MoneyData >= priceItem)
            {
                gameObjectsItem[i]?.SetActive(false);
                gameObjectsItemImage[i].SetActive(false);
            }
            else
            {
                gameObjectsItem[i]?.SetActive(true);
                gameObjectsItemImage[i]?.SetActive(true);
            }
        }
    }
}
