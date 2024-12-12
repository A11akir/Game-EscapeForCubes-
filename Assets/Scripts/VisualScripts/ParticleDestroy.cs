using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private Transform originalParent;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        originalParent = transform.parent;
    }

    public void PlayParticleAndDetach()
    {
        if (particleSystem != null)
        {
            transform.parent = null;

            gameObject.SetActive(true);

            particleSystem.Play();

            StartCoroutine(WaitForParticleAndReattach());
        }
    }

    private IEnumerator WaitForParticleAndReattach()
    {
        while (particleSystem.isPlaying)
        {
            yield return null;
        }
        transform.parent = originalParent;
    }
}

