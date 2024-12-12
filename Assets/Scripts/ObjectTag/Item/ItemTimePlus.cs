
using UnityEngine;


public class ItemTimePlus : ObjectTag, IItem
{
    [SerializeField] private ParticleDestroy particleDestroy;

    [SerializeField] private Timer time;

    [SerializeField] private int debafTime = 1;

    [SerializeField] PlayerTrigger playerTrigger;

    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.ItemTimePlus;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.TryGetComponent(out PlayerTrigger player))
        {
            time.SecondCountMax += debafTime;

            particleDestroy.PlayParticleAndDetach();

            gameObject.SetActive(false);
        }
    }
}
