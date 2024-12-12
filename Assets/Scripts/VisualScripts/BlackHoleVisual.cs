using DG.Tweening;
using UnityEngine;

public class BlackHoleVisual : MonoBehaviour
{
    [SerializeField] private ObstacleHole obstacleHole;

    private void OnEnable()
    {
        Vector3 currentScale = transform.localScale;

        transform.localScale = Vector3.zero;

        transform.DORotate(new Vector3(0, 0, 360), 10f, RotateMode.LocalAxisAdd)
                 .SetLoops(-1).SetEase(Ease.Linear);

        Tween animation = transform.DOScale(currentScale, obstacleHole.delayHole).SetDelay(0.15f);
    }
}
