using UnityEngine;

public class EnemySimple : ObjectTag, IEnemy
{
    [SerializeField] private ExpScript expScript;
    [SerializeField] private ParticleDestroy particleDestroy;
    [SerializeField] private PickScripts pickScripts;

    [SerializeField] private int expCount = 1;
    
    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.EnemySimple;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {       
        if (col.transform.TryGetComponent(out PlayerTrigger player))
        {
            expScript.ChangedExp(expCount);

            particleDestroy.PlayParticleAndDetach();

            pickScripts.OnSoundPick();

            gameObject.SetActive(false);
        }
    }
}
