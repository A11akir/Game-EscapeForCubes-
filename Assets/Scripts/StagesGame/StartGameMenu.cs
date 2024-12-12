using System;
using UnityEngine;
using Zenject;

public class StartGameMenu : MonoBehaviour
{
    [SerializeField] GameObject WonWindow;
    [SerializeField] GameObject MenuWindow;
    [SerializeField] GameObject CoinsWindow;
    [SerializeField] GameObject ShopWindow;
    [SerializeField] GameObject PauseWindow;
    [SerializeField] GameObject ShopItemWindow;
    [SerializeField] GameObject Canvas;

    private SaveJson saveJson;
    private AddItem addItem;

    [Inject]
    public void Construct(SaveJson saveJson, AddItem addItem)
    {
        this.saveJson = saveJson;
        this.addItem = addItem;
    }

    public event Action GameStarted;

    private void Start()
    {
        Time.timeScale = 0;       

        
        Canvas.SetActive(true);
        PauseWindow.SetActive(false);
        WonWindow.SetActive(false);
        ShopWindow.SetActive(false);
        ShopItemWindow.SetActive(false);
        CoinsWindow.SetActive(true);
        MenuWindow.SetActive(true);
        
        saveJson.Load();
        addItem.ItemLoad();
        GameStarted();
    }
}
