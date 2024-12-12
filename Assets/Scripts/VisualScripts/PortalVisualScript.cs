using DG.Tweening;
using UnityEngine;

public class PortalVisualScript : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector3.zero;


        transform.DORotate(new Vector3(0, 0, 75 * 1), 2f, RotateMode.LocalAxisAdd)
                 .SetLoops(-1);

        Sequence animationSequence = DOTween.Sequence();
        animationSequence.Append(transform.DOScale(2f, 0.15f))
                        .AppendInterval(0.45f)
                        .Append(transform.DOScale(Vector3.zero, 0.15f))
                        .OnComplete(() => gameObject.SetActive(false));
    }
}
