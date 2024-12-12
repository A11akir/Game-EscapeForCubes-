using DG.Tweening;
using UnityEngine;

public class EnemyItemSpawnVisual : MonoBehaviour
{
    [SerializeField] PortalVisualScript portalVisualScript;
    [SerializeField] private GameObject portal;

    private void OnEnable()
    {       
        portal.SetActive(true);

        Vector3 currentScale = transform.localScale;

        transform.localScale = Vector3.zero;
      
        Tween animation = transform.DOScale(currentScale, 0.3f).SetDelay(0.15f);
    }
}
