using UnityEngine;

public class PickScripts : MonoBehaviour
{
    [SerializeField] AudioSource soundPick;

    private void OnEnable()
    {
        soundPick = GetComponent<AudioSource>();
    }

    public void OnSoundPick()
    {
        Debug.Log("Pick");
        soundPick.Play();
    }
}
