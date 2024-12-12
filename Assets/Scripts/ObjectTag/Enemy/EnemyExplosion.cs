using System.Collections;
using UnityEngine;

public class EnemyExplosion : ObjectTag, IEnemy
{
    [SerializeField] private ParticleDestroy particleDestroy;
    [SerializeField] private ExplosionVisual explosionVisual;
    [SerializeField] ExpScript expScript;

    [SerializeField] private int expCount = 1;

    private bool explosionDone = false;

    [SerializeField] private float ForceRadius = 5;
    [SerializeField] private float ForceStrenght = 500;
    [SerializeField] private float delayExplode = 2f;

    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.EnemyExplosion;
    }

    

    private void OnEnable()
    {
        this.StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        this.StopCoroutine(LifeRoutine());
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

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(delayExplode);

        Explode();

        this.gameObject.SetActive(false);
    }

    private void Explode()
    {
        if (explosionDone == true) return;
        explosionDone = true;

        Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position, ForceRadius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            if (!overlappedColliders[i].transform.TryGetComponent(out IObstacle obstacle) &&
                !overlappedColliders[i].transform.TryGetComponent(out IWall wall))
            {
                Rigidbody2D rigidbody = overlappedColliders[i].attachedRigidbody;

                if (rigidbody)
                {
                    rigidbody.AddExplosionForce(ForceStrenght, transform.position, ForceRadius, .1f, ForceMode2D.Impulse);

                    EnemyExplosion enemyExplosion = rigidbody.GetComponent<EnemyExplosion>();

                    ObjectTag objectTag = rigidbody.GetComponent<ObjectTag>();

                    if (enemyExplosion)
                    {
                        if (Vector2.Distance(transform.position, rigidbody.position) < ForceRadius / 1.45)
                        {
                            enemyExplosion.Explode();

                            explosionVisual.PlayParticleExplosion();

                            objectTag.gameObject.SetActive(false);
                        }

                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ForceRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, ForceRadius/1.45f);
    }
}
