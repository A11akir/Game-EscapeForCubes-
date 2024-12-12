using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ExplosionVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystemExplosion;
    private Transform originalParent;

    private void Start()
    {
        originalParent = transform.parent;
        particleSystemExplosion.gameObject.SetActive(true);
    }

    public void PlayParticleExplosion()
    {
        if (particleSystemExplosion != null)
        {
            transform.parent = null;

            gameObject.SetActive(true);

            particleSystemExplosion.Play();

            StartCoroutine(WaitForParticleAndReattach());
        }
    }

    private IEnumerator WaitForParticleAndReattach()
    {
        while (particleSystemExplosion.isPlaying)
        {
            yield return null;
        }
        transform.parent = originalParent;
    }
}

