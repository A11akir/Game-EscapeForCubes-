using UnityEngine;

public class EnemyStealth : ObjectTag, IEnemy
{
    [SerializeField] private ExpScript expScript;
    [SerializeField] private ParticleDestroy particleDestroy;
    [SerializeField] private PickScripts pickScripts;

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

            pickScripts.OnSoundPick();
            particleDestroy.PlayParticleAndDetach();

            gameObject.SetActive(false);
        }
    }
}
