using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    private float rotationSpeed = 5f;


    private void OnEnable()
    {
        transform.DORotate(new Vector3(0, 0, 360), rotationSpeed, RotateMode.LocalAxisAdd)
                 .SetLoops(-1).SetEase(Ease.Linear);
    }
}