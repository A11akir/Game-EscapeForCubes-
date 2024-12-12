using UnityEngine;

public class EnemyStealth : ObjectTag, IEnemy
{
    [SerializeField] private ExpScript expScript;
    [SerializeField] private ParticleDestroy particleDestroy;

    [SerializeField] private int expCount = 1;

    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.EnemyStealth;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.TryGetComponent(out PlayerTrigger player))
        {
            expScript.ChangedExp(expCount);

            particleDestroy.PlayParticleAndDetach();

            gameObject.SetActive(false);
        }
    }
}
