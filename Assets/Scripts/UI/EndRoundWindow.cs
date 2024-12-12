using TMPro;
using UnityEngine;
using Zenject;

public class EndRoundWindow : MonoBehaviour
{
    private Timer timer;
    private ExpScript expScript;
    private EndRoundScript endRoundScript;
    private LevelsStars levelsStars;
    private GiveCoins giveCoins;

    private int spendTimeUI;

    [Inject]
    private void Construct(Timer timer, ExpScript expScript, EndRoundScript endRoundScript, LevelsStars levelsStars, GiveCoins giveCoins)
    {
        this.timer = timer;
        this.expScript = expScript;
        this.endRoundScript = endRoundScript;
        this.levelsStars = levelsStars;
        this.giveCoins = giveCoins;
    }

    [SerializeField] public GameObject WonWindow;
    [SerializeField] private GameObject[] stars;
    [SerializeField] private TextMeshProUGUI spendTimeText;
    [SerializeField] private TextMeshProUGUI congratulationsText;
    [SerializeField] private TextMeshProUGUI moneyRewardText;


    private void Start()
    {
        WonWindow.SetActive(false);
        ActiveStars(3, false);
        
        endRoundScript.RoundChanged += OnRoundChanged;
    }

    private void OnDestroy()
    {
        endRoundScript.RoundChanged -= OnRoundChanged;
    }

    private void ActiveStars(int count, bool active)
    {
        for (int i = 0; i < count; i++)
        {
            stars[i].SetActive(active);
        }
    }

    private void OnRoundChanged()
    {
        ActiveEndRoundWindow();

        if (expScript.CurrentExp >= expScript.MaxExp)
        {
            spendTimeUI = (int)(timer.secondCount - timer.SecondCountMax);

            spendTimeText.text = $"Spend time: {spendTimeUI} sec";
        }
        if (timer.SecondCountMax <= 0)
        {
            spendTimeText.text = "";
        }
    }
    private void ActiveEndRoundWindow()
    {
        WonWindow.SetActive(true);

        ActiveStars(3, false);

        if (expScript.CurrentExp >= levelsStars.scoreThreeStar && !stars[2].activeSelf)
        {
            ActiveStars(3, true);
            congratulationsText.text = "Congratulations!";
        }
        else if (expScript.CurrentExp >= levelsStars.scoreTwoStar && !stars[1].activeSelf)
        {
            ActiveStars(2, true);
            congratulationsText.text = "Congratulations!";
        }
        else if (expScript.CurrentExp >= levelsStars.scoreOneStar && !stars[0].activeSelf)
        {
            ActiveStars(1, true);
            congratulationsText.text = "Congratulations!";
        }
        else if (expScript.CurrentExp <= levelsStars.scoreOneStar)
        {
            ActiveStars(3, false);
            congratulationsText.text = "Try again!";
        }

        moneyRewardText.text = giveCoins.valueMoney.ToString();
    }
}

