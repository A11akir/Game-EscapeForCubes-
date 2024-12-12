using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintWindowScript : MonoBehaviour
{
    [SerializeField] private GameObject hint;

    private void OnMouseEnter()
    {
        hint.SetActive(true);
    }

    private void OnMouseExit()
    {
        hint.SetActive(false);
    }
}
