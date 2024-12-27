using System;
using UnityEngine;
using Zenject;

public class ExpScript : MonoBehaviour
{   
    public int MaxExp;
    public int CurrentExp;

    public event Action<float> ExpChanged;

    public void ChangedExp(int value)
    {
        CurrentExp += value;

        float _currentExpAsPercanntage = (float)CurrentExp / MaxExp;
        ExpChanged?.Invoke(_currentExpAsPercanntage);
    }
}