
using UnityEngine;

public class ItemSpeedMinus : ObjectTag, IItem
{
    [SerializeField] private ParticleDestroy particleDestroy;
    [SerializeField] private PickScripts pickScripts;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private int debafSpeed = 5;

    [SerializeField] PlayerTrigger playerTrigger;

    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.ItemSpeedMinus;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.TryGetComponent(out PlayerTrigger player))
        {
            playerMovement.Speed -= debafSpeed;
            pickScripts.OnSoundPick();
            particleDestroy.PlayParticleAndDetach();

            gameObject.SetActive(false);
        }
    }
}
