using UnityEngine;

public class ItemTimeMinus : ObjectTag, IItem
{
    [SerializeField] private ParticleDestroy particleDestroy;

    [SerializeField] private int debafTime = 1;

    [SerializeField] PlayerTrigger playerTrigger;

    [SerializeField] Timer timer;

    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.ItemTimeMinus;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.TryGetComponent(out PlayerTrigger player))
        {
            timer.SecondCountMax -= debafTime;

            timer.ChangedTime();

            particleDestroy.PlayParticleAndDetach();

            gameObject.SetActive(false);
        }
    }
}
