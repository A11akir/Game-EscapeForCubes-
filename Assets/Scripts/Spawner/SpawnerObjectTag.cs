using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpawnerObjectTag : MonoBehaviour
{
    [HideInInspector] private int poolCount;
    [HideInInspector] public int PoolCount { get => poolCount; set { poolCount = (value >= 0) ? value : 0; } }

    [HideInInspector] private bool autoExpand = false;

    [Inject] private Timer timer;

    public List<ObjectTag> objectTags;

    [HideInInspector] public float spawnDelay;
    [HideInInspector] public int startSpawnDelay = 1;

    public PoolMono<ObjectTag> pool;

    private void Start()
    {
        pool = new PoolMono<ObjectTag>(objectTags, poolCount, this.transform);

        LaunchSpawner();
    }

    public void LaunchSpawner()
    {       
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        
        yield return new WaitForSeconds(startSpawnDelay);

        spawnDelay = (timer.secondCount-1.5f) / (float)poolCount;       

        for (int i = 0; i < poolCount; i++)
        {
            
            CreateEnemy(pool);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void CreateEnemy(PoolMono<ObjectTag> pool)
    {
        var enemy = pool.GetFreeElement();

        if (enemy.objectTagEnum != ObjectTagEnum.ObstacleShuriken)
        { enemy.transform.position = new Vector2(Random.Range(16f, -16f), Random.Range(8f, -8f)); }
        
    } 
}
