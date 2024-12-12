using UnityEngine;
using Zenject;

public class PauseGame : MonoBehaviour
{
    private GameInput gameInput;

    [Inject] ButtonScripts buttonScripts;

    [SerializeField] GameObject MenuWindow1;
    [SerializeField] GameObject MenuWindow2;
    [SerializeField] GameObject ShopWindow;
    [SerializeField] GameObject WonWindow;

    [HideInInspector] public bool isPause = false;

    private void OnEnable()
    {
        gameInput.Enable();
    }

    private void OnDisable()
    {
        gameInput.Disable();
    }
    private void Awake()
    {
        gameInput = new GameInput();

        gameInput.UI.Pause.performed += context => OnPause();
    }

    private void OnDestroy()
    {
        gameInput.UI.Pause.performed -= context => OnPause();
    }

    public void OnPause()
    {
        if (!MenuWindow1.activeSelf && !ShopWindow.activeSelf && !WonWindow.activeSelf && !MenuWindow2.activeSelf)
        {
            if (!isPause)
            {
                Time.timeScale = 0f;
                isPause = true;
                buttonScripts.Pause();
            }
            else
            {
                Time.timeScale = 1f;
                isPause = false;
                buttonScripts.Play();
            }
        }
    }

    public void PauseForButton()
    {
        Time.timeScale = 0f;
    }

    public void PlayForButton()
    {
        Time.timeScale = 1f;
    }
}
