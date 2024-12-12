using System;
using UnityEngine;
using Zenject;

public class LevelsStars : MonoBehaviour
{
    [Inject] private ExpScript expScript;
    [Inject] private StartRoundScript startRoundScript;
    [Inject] private EndRoundScript endRoundScript;
    [Inject] private ButtonScripts buttonScripts;
    [Inject] private StoredData storedData;

    [HideInInspector] public float scoreOneStar;
    [HideInInspector] public float scoreTwoStar;
    [HideInInspector] public float scoreThreeStar;

    public event Action StarsDataChanged;

    public int[] bestStarsForLevel;

    public int currentLevel;
    private int levelsCount = 100;

    private void Awake()
    {
        bestStarsForLevel = new int[levelsCount];
    }

    private void OnEnable()
    {
        endRoundScript.RoundChanged += OnRoundChanged;
        
        startRoundScript.RoundStarted += OnRoundStarted; 
    }

    private void OnDisable()
    {
        endRoundScript.RoundChanged -= OnRoundChanged;
        startRoundScript.RoundStarted -= OnRoundStarted;
    }

    private void OnRoundStarted()
    {
        scoreOneStar = expScript.MaxExp / 3;
        scoreTwoStar = expScript.MaxExp / 2;
        scoreThreeStar = expScript.MaxExp / 1;
    }

    private void OnRoundChanged()
    {
        currentLevel = buttonScripts.currentLevel - 1;

        int stars = bestStarsForLevel[currentLevel];

        int starsForCurrentLevel = CalculateStarsForCurrentLevel(expScript.CurrentExp);

        if (starsForCurrentLevel > bestStarsForLevel[currentLevel])
        {

            bestStarsForLevel[currentLevel] = starsForCurrentLevel;

            storedData.SetBestStarsForLevel(currentLevel, starsForCurrentLevel);
        }

        

        StarsDataChanged?.Invoke();

    }

    public int CalculateStarsForCurrentLevel(float currentExp)
    {
        if (currentExp >= scoreThreeStar)
            return 3;
        else if (currentExp >= scoreTwoStar)
            return 2;
        else if (currentExp >= scoreOneStar)
            return 1;
        else
            return 0;
    }


}
