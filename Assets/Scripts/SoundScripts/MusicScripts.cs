using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MusicScripts : MonoBehaviour
{
    [Inject] private EndRoundScript endRoundScript;
    [Inject] private StartRoundScript startRoundScript;
    private AudioSource music;

    private void Awake()
    {
        music = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        endRoundScript.RoundChanged += MusicVolumeMinus;
        startRoundScript.RoundStarted += MusicVolumePlus;
    }
    private void OnDisable()
    {
        endRoundScript.RoundChanged -= MusicVolumeMinus;
        startRoundScript.RoundStarted -= MusicVolumePlus;
    }

    public void MusicVolumeMinus()
    {
        music.volume = .1f;
    }

    public void MusicVolumePlus()
    {
        music.volume = .4f;
    }
}
