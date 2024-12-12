using System;
using TMPro;
using UnityEngine;
using Zenject;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    [Inject] private Timer timer;

    private void OnEnable()
    {
        timer.TimeChanged += OnTimeChanged;
    }

    private void OnDisable()
    {
        timer.TimeChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(float SecondCountMax, float secondCount)
    {
        textMeshPro.text = $"{Convert.ToInt32(SecondCountMax)}";

        if (SecondCountMax >= (secondCount / 3))
        {
            textMeshPro.color = Color.white;
        }
        if (SecondCountMax <= (secondCount / 3))
        {
            textMeshPro.color = Color.yellow;
        }
        if (SecondCountMax <= (secondCount / 10))
        {
            textMeshPro.color = Color.red;
        }
    }
}
