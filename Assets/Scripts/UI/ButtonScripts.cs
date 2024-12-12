using UnityEngine;
using Zenject;
using System;

public class ButtonScripts : MonoBehaviour
{
    private EndRoundScript endRoundScript;
    private LevelConfigSpawner levelConfig;
    private StartRoundScript startRoundScript;
    private ChangeSkin changeSkin;
    private AddItem addItem;
    private PauseGame pauseGame;

    [Inject]
    public void Construct(EndRoundScript endRoundScript, LevelConfigSpawner levelConfig, 
        StartRoundScript startRoundScript, ChangeSkin changeSkin, AddItem addItem, PauseGame pauseGame)
    {
        this.endRoundScript = endRoundScript;
        this.levelConfig = levelConfig;
        this.startRoundScript = startRoundScript;
        this.changeSkin = changeSkin;
        this.addItem = addItem;
        this.pauseGame = pauseGame;
    }

    [HideInInspector] public int currentLevel;

    private Action[] levelMethods;
    private Action[] levelConfigMethods;

    private Action[] skinButtonMethods;
    private Action[] skin_X_Methods;

    [SerializeField] private GameObject WonWindow;
    [SerializeField] private GameObject MenuWindow1;
    [SerializeField] private GameObject MenuWindow2;
    [SerializeField] private GameObject ShopWindow;
    [SerializeField] private GameObject SkinWindow;
    [SerializeField] private GameObject ItemWindow;
    [SerializeField] private GameObject PauseWindow;
    [SerializeField] private GameObject PauseMiniWindow;
    [SerializeField] private GameObject CurencyWindow;
    [SerializeField] private GameObject[] levelsButton;


    private void Start()
    {
        skinButtonMethods = new Action[]
        {
            () => Skin_X_Button(1),
            () => Skin_X_Button(2),
            () => Skin_X_Button(3),
            () => Skin_X_Button(4),
        };
        skin_X_Methods = new Action[]
        {
            () => changeSkin.SkinBy(1),
            () => changeSkin.SkinBy(2),
            () => changeSkin.SkinBy(3),
            () => changeSkin.SkinBy(4),
        };

        levelMethods = new Action[]
        {
            () => Level_X_Button(1),
            () => Level_X_Button(2),
            () => Level_X_Button(3),
            () => Level_X_Button(4),
            () => Level_X_Button(5),
            () => Level_X_Button(6),
            () => Level_X_Button(7),
            () => Level_X_Button(8),
            () => Level_X_Button(9),
            () => Level_X_Button(10),
            () => Level_X_Button(11),
            () => Level_X_Button(12),
            () => Level_X_Button(13),
            () => Level_X_Button(14),
            () => Level_X_Button(15),
            () => Level_X_Button(16),
            () => Level_X_Button(17),
            () => Level_X_Button(18),
            () => Level_X_Button(19),
            () => Level_X_Button(20)
        };
        levelConfigMethods = new Action[]
        {
            levelConfig.Level1Config,
            levelConfig.Level2Config,
            levelConfig.Level3Config,
            levelConfig.Level4Config,
            levelConfig.Level5Config,
            levelConfig.Level6Config,
            levelConfig.Level7Config,
            levelConfig.Level8Config,
            levelConfig.Level9Config,
            levelConfig.Level10Config,
            levelConfig.Level11Config,
            levelConfig.Level12Config,
            levelConfig.Level13Config,
            levelConfig.Level14Config,
            levelConfig.Level15Config,
            levelConfig.Level16Config,
            levelConfig.Level17Config,
            levelConfig.Level18Config,
            levelConfig.Level19Config,
            levelConfig.Level20Config
        };
    }

    public void Menu()
    {
        PauseWindow.SetActive(false);
        PauseMiniWindow.SetActive(false);
        ShopWindow.SetActive(false);
        WonWindow.SetActive(false);
        MenuWindow1.SetActive(true);

        if (pauseGame.isPause == true)
        {
            endRoundScript.RefreshSpawner();
            pauseGame.isPause = false;
        }
    }

    public void Pause()
    {
        if (!MenuWindow1.activeSelf && !WonWindow.activeSelf && !MenuWindow2.activeSelf)
        {
            pauseGame.isPause = true;
            pauseGame.PauseForButton();
            PauseWindow.SetActive(true);
            PauseMiniWindow.SetActive(false);
        }    
    }

    public void Play()
    {
        pauseGame.isPause = false;
        pauseGame.PlayForButton();
        PauseWindow.SetActive(false);
        PauseMiniWindow.SetActive(true);
    }

    public void Next()
    {
        WonWindow.SetActive(false);
        MenuWindow1.SetActive(false);
        MenuWindow2.SetActive(false);

        endRoundScript.RefreshRound();
        endRoundScript.RefreshSpawner();

        if (currentLevel < levelMethods.Length)
        {
            levelMethods[currentLevel]();            
        }
        else
        {
            Menu();
        }
    }

    public void Shop()
    {
        WonWindow.SetActive(false);
        MenuWindow1.SetActive(false);
        MenuWindow2.SetActive(false);
        ShopWindow.SetActive(true);
        CurencyWindow.transform.localPosition = new Vector2(-912, 400);
    }

    public void Skin()
    {
        ItemWindow.SetActive(false);
        SkinWindow.SetActive(true);
    }

    public void Item()
    {
        ItemWindow.SetActive(true);
        SkinWindow.SetActive(false);
    }

    public void Retry()
    {
        pauseGame.isPause = false;
        WonWindow.SetActive(false);
        MenuWindow1.SetActive(false);
        MenuWindow2.SetActive(false);

        endRoundScript.RefreshRound();
        endRoundScript.RefreshSpawner();

        levelMethods[currentLevel-1]();

    }
    public void Item_X_Button(int x)
    {
        addItem.ItemBy(x);
    }

    public void Skin_X_Button(int x)
    {
        changeSkin.SkinBy(x);
    }

    public void Level_X_Button(int level)
    {
        PauseWindow.SetActive(false);
        PauseMiniWindow.SetActive(true);
        MenuWindow1.SetActive(false);
        MenuWindow2.SetActive(false);
        Time.timeScale = 1.0f;

        endRoundScript.RefreshRound();
        


        levelConfigMethods[level - 1]();

        currentLevel = level;


        startRoundScript.StartedRound();
    }

    public void List1Button()
    {
        MenuWindow1.SetActive(false);
        MenuWindow2.SetActive(true);
    }

    public void List2Button()
    {
        MenuWindow2.SetActive(false);
        MenuWindow1.SetActive(true);
    }

    public void SelectBoughtSkinButton() => changeSkin.SelectBoughtSkin();
    public void SelectDefaultSkinButton() => changeSkin.SelectStandartSkin();
}
