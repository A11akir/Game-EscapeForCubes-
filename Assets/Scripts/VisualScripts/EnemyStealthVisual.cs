using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyStealthVisual : MonoBehaviour
{
    private float delayEscape = 1.5f;
    private float flashTimeCoolDown = 0.25f;

    private Tween tween;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        this.StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        this.StopCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(delayEscape);
        tween = spriteRenderer.DOFade(.3f, .25f);
        yield return new WaitForSeconds(flashTimeCoolDown);
        tween = spriteRenderer.DOFade(.75f, .25f);
        yield return new WaitForSeconds(flashTimeCoolDown);
        tween = spriteRenderer.DOFade(.3f, .25f);
        yield return new WaitForSeconds(flashTimeCoolDown);
        tween = spriteRenderer.DOFade(.75f, .25f);
        yield return new WaitForSeconds(flashTimeCoolDown);
        tween = spriteRenderer.DOFade(.0f, .25f);

        this.gameObject.SetActive(false);
    }
}
