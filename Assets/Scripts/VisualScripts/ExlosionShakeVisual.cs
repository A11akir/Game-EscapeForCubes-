using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ExlosionShakeVisual : MonoBehaviour
{
    private float delayRotate = 1.3f;

    private void OnEnable()
    {
        this.StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        this.StopCoroutine(LifeRoutine());
    }

    private void RotateExplode()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(new Vector3(0, 0, -10), 0.04f).SetEase(Ease.Linear));

        sequence.Append(transform.DORotate(new Vector3(0, 0, 10), 0.04f).SetEase(Ease.Linear));

        sequence.Append(transform.DORotate(Vector3.zero, 0.05f).SetEase(Ease.Linear));

        sequence.SetLoops(10);
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(delayRotate);

        RotateExplode();
    }
}
