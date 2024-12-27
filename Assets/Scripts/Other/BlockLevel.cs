using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BlockLevel : MonoBehaviour
{
    [Inject] private EndRoundScript endRoundScript;
    [Inject] private ButtonScripts levelsStars;
    [Inject] private SaveJson saveJson;

    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] imagesBlock;

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
        buttons[levelsStars.currentLevel].interactable = true;
        imagesBlock[levelsStars.currentLevel].SetActive(false);
    }

    public void BlockLoad()
    {
        for (int i = 0; i < saveJson.levelsStarsViewData.Count+1; i++)
        {
            buttons[i].interactable = true;
            imagesBlock[i].SetActive(false);
        }
        
    }
}
