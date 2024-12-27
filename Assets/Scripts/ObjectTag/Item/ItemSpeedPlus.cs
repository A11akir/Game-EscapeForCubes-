
using UnityEngine;


public class ItemSpeedPlus : ObjectTag, IItem
{
    [SerializeField] private ParticleDestroy particleDestroy;
    [SerializeField] private PickScripts pickScripts;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private int bafSpeed = 5;

    [SerializeField] PlayerTrigger playerTrigger;

    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.ItemSpeedPlus;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.TryGetComponent(out PlayerTrigger player))
        {
            playerMovement.Speed += bafSpeed;
            pickScripts.OnSoundPick();
            particleDestroy.PlayParticleAndDetach();

            gameObject.SetActive(false);
        }
    }
}
