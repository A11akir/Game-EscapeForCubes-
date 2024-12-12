using UnityEngine;
using Zenject;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] private Sprite SpriteShadowRobot;
    [SerializeField] private Sprite SpriteShadowStandart;

    [SerializeField] private SpriteRenderer SpriteShadow;

    [SerializeField] private GameObject PlayerRobot;
    [SerializeField] private GameObject PlayerStandart;
    [SerializeField] private GameObject[] ButtonSkin1;
    [SerializeField] private GameObject ChangeSkin1;
    [SerializeField] private GameObject ChangeSkin2;
    [SerializeField] private GameObject ShadowPlayerStandart;
    [SerializeField] private GameObject ShadowPlayerRobot;
    [SerializeField] private GameObject ShadowGO;

    private PurchaseSystem purchaseSystem;
    private GiveCoins giveCoins;
    private SaveJson saveJson;

    [Inject]
    public void Construct(PurchaseSystem purchaseSystem, GiveCoins giveCoins, SaveJson saveJson)
    {
        this.purchaseSystem = purchaseSystem;
        this.giveCoins = giveCoins;
        this.saveJson = saveJson;
    }

    private void Awake()
    {
        SpriteShadow = ShadowGO.GetComponent<SpriteRenderer>();
    }

    public void SkinBy(int number)
    {
        purchaseSystem.isBought = true;

        SelectSkin(number);

        giveCoins.WasteMoney(purchaseSystem.prices[number - 1]);
    }

    public void SkinLoad()
    {
        int number = saveJson.SkinPlayerData;

        SelectSkin(number);

        if (number == 1 || number == -1)
        {
            foreach (var item in ButtonSkin1)
            {
                item.SetActive(false);
            }
            
        }
    }

    public void SelectStandartSkin()
    {
        PlayerStandart.SetActive(true);
        ShadowPlayerStandart.SetActive(true);
        PlayerRobot.SetActive(false);
        ShadowPlayerRobot.SetActive(false);
        SpriteShadow.sprite = SpriteShadowStandart;

        ShadowPlayerStandart.transform.position = PlayerStandart.transform.position;

        saveJson.SkinPlayerData = -1;
        saveJson.Save();
        ChangeSkin1.SetActive(false);
        ChangeSkin2.SetActive(true);
        foreach (var item in ButtonSkin1)
        {
            item.SetActive(false);
        }
    }

    public void SelectBoughtSkin()
    {
        SelectNewSkin();

        saveJson.SkinPlayerData = 1;
        saveJson.Save();
        ChangeSkin2.SetActive(false);
    }

    private void SelectSkin(int number)
    {
        if (number == 1)
        {
            SelectNewSkin();

            saveJson.SkinPlayerData = number;          
        }

        if (number == -1)
        {
            SelectStandartSkin();

            saveJson.SkinPlayerData = number;
        }
    }

    private void SelectNewSkin()
    {
        PlayerStandart.SetActive(false);
        ShadowPlayerStandart.SetActive(false);
        PlayerRobot.SetActive(true);
        ShadowPlayerRobot.SetActive(true);
        SpriteShadow.sprite = SpriteShadowRobot;
        ShadowPlayerRobot.transform.position = PlayerRobot.transform.position;
        ChangeSkin1.SetActive(true);
        ChangeSkin2.SetActive(false);
        foreach (var item in ButtonSkin1)
        {
            item.SetActive(false);
        }
    }
}


