using UnityEngine;
using Zenject;

public class HideLevelsView : MonoBehaviour
{
    [SerializeField] GameObject[] parentStarsOnButton;

    private StartGameMenu startGameMenu;
    private LevelsStars levelsStars;
    private StoredData storedData;

    [Inject]
    public void Construct(StartGameMenu startGameMenu, LevelsStars levelsStars, StoredData storedData)
    {
        this.startGameMenu = startGameMenu;
        this.levelsStars = levelsStars;
        this.storedData = storedData;
    }       

    private void OnEnable()
    {

        levelsStars.StarsDataChanged += OnStarsDataChanged;
        startGameMenu.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        levelsStars.StarsDataChanged -= OnStarsDataChanged;
        startGameMenu.GameStarted -= OnGameStarted;
    }

    public void ViewStars()
    {
        for (int i = 0; i < storedData.levelsStarsView.Count; i++)
        {
            parentStarsOnButton[i].gameObject.SetActive(true);

            ActiveStars(i, 3, false, true);
            ActiveStars(i, 3, true, false);

            ActiveStars(i, storedData.levelsStarsView[i], true, true);
        }
    }

    private void ActiveStars(int levelCount, int countStars, bool active, bool activeStarsOrPhone)
    {
        if (activeStarsOrPhone)
        {
            if (countStars >= 1)
                parentStarsOnButton[levelCount].transform.GetChild(firstActivesStars()).gameObject.SetActive(active);
            if (countStars >= 2)
                parentStarsOnButton[levelCount].transform.GetChild(secondActivesStars()).gameObject.SetActive(active);
            if (countStars == 3)
                parentStarsOnButton[levelCount].transform.GetChild(thirdActivesStars()).gameObject.SetActive(active);
        }
        else
        {
            if (countStars >= 1)
                parentStarsOnButton[levelCount].transform.GetChild(firstInactivesStars()).gameObject.SetActive(active);
            if (countStars >= 2)
                parentStarsOnButton[levelCount].transform.GetChild(secondInactivesStars()).gameObject.SetActive(active);
            if (countStars == 3)
                parentStarsOnButton[levelCount].transform.GetChild(thirdInactivesStars()).gameObject.SetActive(active);
        }
    }

    private void OnGameStarted()
    {

        for (var i = 0; i < parentStarsOnButton.Length; i++)
        {
            if (i > 0)
                parentStarsOnButton[i].gameObject.SetActive(false);
        }

        ActiveStars(0, 3, false, true);
        ActiveStars(0, 3, true, false);

        ViewStars();
    }

    private void OnStarsDataChanged() => ViewStars();

    private int firstInactivesStars() => 0;
    private int firstActivesStars() => 1;
    private int secondInactivesStars() => 2;
    private int secondActivesStars() => 3;
    private int thirdInactivesStars() => 4;
    private int thirdActivesStars() => 5;
}
