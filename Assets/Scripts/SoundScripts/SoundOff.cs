using UnityEngine;

public class SoundOff : MonoBehaviour
{
    [SerializeField] private AudioListener audioListener;
    [SerializeField] private GameObject redLineImage;

    private bool isSoundOff = false;

    public void SoundButton()
    {
        isSoundOff = !isSoundOff;

        audioListener.enabled = !isSoundOff;
        redLineImage.SetActive(isSoundOff);
    }
}
