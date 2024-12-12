using TMPro;
using UnityEngine;
using Zenject;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private GameObject CurencyWindowUI;
    [SerializeField] private TextMeshProUGUI amountView;

    private EndRoundScript endRoundScript;
    private StartRoundScript startRoundScript;

    [Inject]
    public void Construct(EndRoundScript endRoundScript, StartRoundScript startRoundScript)
    {
        this.endRoundScript = endRoundScript;
        this.startRoundScript = startRoundScript;
    }

    public void AmountChanged(string amount)
    {
        amountView.text = amount;
        CurencyWindowUI.transform.localPosition = new Vector2(-912, 400);
    }

    private void OnEnable()
    {
        endRoundScript.RoundChanged += OnRoundChanged;
        startRoundScript.RoundStarted += OnRoundStarted;
    }
    private void OnDisable()
    {
        endRoundScript.RoundChanged += OnRoundChanged;
        startRoundScript.RoundStarted -= OnRoundStarted;
    }

    private void OnRoundStarted()
    {
        CurencyWindowUI.transform.localPosition = new Vector2 (-1100, 400);
    }

    private void OnRoundChanged()
    {
        CurencyWindowUI.transform.localPosition = new Vector2(-912, 400);
    }
}
