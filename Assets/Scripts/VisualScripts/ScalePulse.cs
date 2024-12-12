using UnityEngine;
using DG.Tweening;

public class ScalePulse : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 1.05f;
    [SerializeField] private float duration = 1.5f; 

    private Vector3 initialScale;
    private Tween currentTween;

    private void Start()
    {
        initialScale = transform.localScale;

        Tween scaleUp = transform.DOScale(initialScale * scaleMultiplier, duration).SetEase(Ease.InOutSine);
        Tween scaleDown = transform.DOScale(initialScale, duration).SetEase(Ease.InOutSine);

        Sequence scaleSequence = DOTween.Sequence();
        scaleSequence.Append(scaleUp);
        scaleSequence.Append(scaleDown);
        scaleSequence.SetLoops(-1);

        currentTween = scaleSequence;
    }

    private void OnDisable()
    {
        currentTween.Kill();
    }
}
