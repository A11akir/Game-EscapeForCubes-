using System;
using TMPro;
using UnityEngine;
using Zenject;

public class Timer : MonoBehaviour
{
    [Inject] private LevelConfigSpawner levelConfig;

    [HideInInspector] public float SecondCountMax;

    [HideInInspector] public float secondCount;

    public event Action<float, float> TimeChanged;

    private void OnLevelStarted()
    {
        secondCount = SecondCountMax;
    }

    private void OnEnable()
    {
        levelConfig.LevelStarted += OnLevelStarted;
    }

    private void OnDisable()
    {
        levelConfig.LevelStarted -= OnLevelStarted;
    }

    private void Update()
    {
        if (SecondCountMax >= 0)
        {
            float previousTime = SecondCountMax;

            SecondCountMax -= 1 * Time.deltaTime;

            if (previousTime > SecondCountMax)
            {
                TimeChanged?.Invoke(SecondCountMax, secondCount);
            }
        }
    }

    public void ChangedTime()
    {
        TimeChanged?.Invoke(SecondCountMax, secondCount);
    }
}
