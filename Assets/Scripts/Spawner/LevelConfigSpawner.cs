using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelConfigSpawner : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private SpawnerObjectTag spawnerObjectTag;
    private Timer timer;
    private ExpScript expScript;
    private PhysicsDebaf physicsDebaf;
    private SaveJson saveJson;

    public event Action LevelStarted;

    [SerializeField] public List<ObjectTag> objectTagsAll;

    [Inject]
    public void Construct(PlayerMovement playerMovement, SpawnerObjectTag spawnerObjectTag, Timer timer, ExpScript expScript, PhysicsDebaf physicsDebaf, SaveJson saveJson)
    {
        this.playerMovement = playerMovement;
        this.spawnerObjectTag = spawnerObjectTag;
        this.timer = timer;
        this.expScript = expScript;
        this.physicsDebaf = physicsDebaf;
        this.saveJson = saveJson;
    }

    public void LevelBuild(int speed, int time, int spawnDelay, int maxExp, List<ObjectTag> objectTag)
    {
        playerMovement.Speed = speed;
        timer.SecondCountMax = time;
        spawnerObjectTag.spawnDelay = spawnDelay;
        expScript.MaxExp = maxExp;
        spawnerObjectTag.PoolCount = objectTag.Count;

        LevelStarted();

        spawnerObjectTag.pool.CreatePool(spawnerObjectTag.PoolCount);
        spawnerObjectTag.LaunchSpawner();
    }

    public void ByItemAddSpawner(ObjectTagEnum tag)
    {
        spawnerObjectTag.objectTags.Add(objectTagsAll[Convert.ToInt32(tag)]);

        saveJson.ByItemListData.Add(Convert.ToInt32(tag));
    }

    public void Level1Config()
    {
        CreateLevelSpawnerList(
            (ObjectTagEnum.EnemySimple, 10)           
            );

        LevelBuild(15, 15, 1, 8, CreateLevelSpawnerList());        
    }

    public void Level2Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemySimple, 8),
            (ObjectTagEnum.EnemyStealth, 2)
            );

        LevelBuild(15 , 15, 1, 8, CreateLevelSpawnerList());
    }

    public void Level3Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemySimple, 5),
            (ObjectTagEnum.EnemyStealth, 5),
            (ObjectTagEnum.ItemTimePlus, 2));

        LevelBuild(15, 15, 1, 9, CreateLevelSpawnerList());
    }

    public void Level4Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemySimple, 5),
            (ObjectTagEnum.EnemyStealth, 6),
            (ObjectTagEnum.EnemyExplosion, 5));

        LevelBuild(15, 10, 1, 12, CreateLevelSpawnerList());
    }

    public void Level5Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemyExplosion, 25)
            );

        LevelBuild(15, 20, 1, 16, CreateLevelSpawnerList());
    }

    public void Level6Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemySimple, 5),
            (ObjectTagEnum.EnemyStealth, 5),
            (ObjectTagEnum.EnemyExplosion, 5),
            (ObjectTagEnum.ItemTimeMinus, 5));

        LevelBuild(15, 20, 1, 14, CreateLevelSpawnerList());
    }

    public void Level7Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemySimple, 5),
            (ObjectTagEnum.EnemyStealth, 5),
            (ObjectTagEnum.EnemyExplosion, 5),
            (ObjectTagEnum.ItemTimePlus, 5),
            (ObjectTagEnum.ItemSpeedPlus, 5)
            );

        LevelBuild(15, 16, 1, 15, CreateLevelSpawnerList());
    }

    public void Level8Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemySimple, 6),
            (ObjectTagEnum.EnemyStealth, 6),
            (ObjectTagEnum.EnemyExplosion, 6),
            (ObjectTagEnum.ItemTimePlus, 2),
            (ObjectTagEnum.ItemSpeedPlus, 2),
            (ObjectTagEnum.ItemSpeedMinus, 2),
            (ObjectTagEnum.ItemTimeMinus, 2)
            );

        LevelBuild(15, 20, 1, 15, CreateLevelSpawnerList());
    }

    public void Level9Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemySimple, 6),
            (ObjectTagEnum.EnemyStealth, 6),
            (ObjectTagEnum.EnemyExplosion, 6),
            (ObjectTagEnum.ItemTimePlus, 2),
            (ObjectTagEnum.ItemSpeedPlus, 2),
            (ObjectTagEnum.ItemSpeedMinus, 2),
            (ObjectTagEnum.ItemTimeMinus, 2),
            (ObjectTagEnum.ObstacleShuriken, 5)
            );

        LevelBuild(15, 20, 1, 15, CreateLevelSpawnerList());
    }

    public void Level10Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 15),
            (ObjectTagEnum.EnemyStealth, 2),
            (ObjectTagEnum.EnemyExplosion, 2),
            (ObjectTagEnum.EnemySimple, 1),
            (ObjectTagEnum.ObstacleShuriken, 20));

        LevelBuild(5, 20, 1, 5, CreateLevelSpawnerList());
    }

    public void Level11Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 2),
            (ObjectTagEnum.ItemSpeedMinus, 2),
            (ObjectTagEnum.ItemTimeMinus, 2),
            (ObjectTagEnum.ItemTimePlus, 2),
            (ObjectTagEnum.EnemyStealth, 5),
            (ObjectTagEnum.EnemyExplosion, 5),
            (ObjectTagEnum.EnemySimple, 10),
            (ObjectTagEnum.ObstacleShuriken, 6));

        LevelBuild(15, 25, 1, 19, CreateLevelSpawnerList());
    }

    public void Level12Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 2),
            (ObjectTagEnum.ItemSpeedMinus, 2),
            (ObjectTagEnum.ItemTimeMinus, 2),
            (ObjectTagEnum.ItemTimePlus, 2),
            (ObjectTagEnum.EnemyStealth, 5),
            (ObjectTagEnum.EnemyExplosion, 5),
            (ObjectTagEnum.EnemySimple, 10),
            (ObjectTagEnum.ObstacleShuriken, 6),
            (ObjectTagEnum.ObstacleHole, 1));

        LevelBuild(15, 25, 1, 19, CreateLevelSpawnerList());
    }

    public void Level13Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 2),
            (ObjectTagEnum.ItemSpeedMinus, 2),
            (ObjectTagEnum.ItemTimeMinus, 2),
            (ObjectTagEnum.ItemTimePlus, 2),
            (ObjectTagEnum.EnemyStealth, 5),
            (ObjectTagEnum.EnemyExplosion, 5),
            (ObjectTagEnum.EnemySimple, 10),
            (ObjectTagEnum.ObstacleShuriken, 7),
            (ObjectTagEnum.ObstacleHole, 2));

        LevelBuild(15, 25, 1, 18, CreateLevelSpawnerList());
    }

    public void Level14Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 2),
            (ObjectTagEnum.ItemSpeedMinus, 3),
            (ObjectTagEnum.ItemTimeMinus, 2),
            (ObjectTagEnum.ItemTimePlus, 2),
            (ObjectTagEnum.EnemyStealth, 5),
            (ObjectTagEnum.EnemyExplosion, 5),
            (ObjectTagEnum.EnemySimple, 10),
            (ObjectTagEnum.ObstacleShuriken, 5),
            (ObjectTagEnum.ObstacleHole, 1));

        StartCoroutine(SpawnPhysicsDebafCourutine(5, 5));

        LevelBuild(15, 25, 1, 18, CreateLevelSpawnerList());
    }

    public void Level15Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.EnemyStealth, 2),
            (ObjectTagEnum.EnemyExplosion, 3),
            (ObjectTagEnum.EnemySimple, 1),
            (ObjectTagEnum.ObstacleHole, 4),
            (ObjectTagEnum.ItemTimeMinus, 10),
            (ObjectTagEnum.ItemTimeMinus, 10),
            (ObjectTagEnum.ObstacleShuriken, 5));


        StartCoroutine(SpawnPhysicsDebafCourutine(2, 20));
        LevelBuild(15, 30, 1, 5, CreateLevelSpawnerList());
    }

    public void Level16Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 3),
            (ObjectTagEnum.ItemSpeedMinus, 3),
            (ObjectTagEnum.ItemTimeMinus, 3),
            (ObjectTagEnum.ItemTimePlus, 3),
            (ObjectTagEnum.EnemyStealth, 15),
            (ObjectTagEnum.EnemyExplosion, 15),
            (ObjectTagEnum.EnemySimple, 10),
            (ObjectTagEnum.ObstacleShuriken, 10),
            (ObjectTagEnum.ObstacleHole, 1));

        StartCoroutine(SpawnPhysicsDebafCourutine(5, 5));
        StartCoroutine(SpawnPhysicsDebafCourutine(20, 5));

        LevelBuild(15, 30, 1, 31, CreateLevelSpawnerList());
    }

    public void Level17Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 3),
            (ObjectTagEnum.ItemSpeedMinus, 3),
            (ObjectTagEnum.ItemTimeMinus, 3),
            (ObjectTagEnum.ItemTimePlus, 3),
            (ObjectTagEnum.EnemyStealth, 15),
            (ObjectTagEnum.EnemyExplosion, 15),
            (ObjectTagEnum.EnemySimple, 10),
            (ObjectTagEnum.ObstacleShuriken, 15),
            (ObjectTagEnum.ObstacleHole, 1));

        StartCoroutine(SpawnPhysicsDebafCourutine(2, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(6, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(10, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(14, 2));

        LevelBuild(15, 30, 1, 31, CreateLevelSpawnerList());
    }

    public void Level18Config()
    {
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 5),
            (ObjectTagEnum.ItemSpeedMinus, 5),
            (ObjectTagEnum.ItemTimeMinus, 5),
            (ObjectTagEnum.ItemTimePlus, 5),
            (ObjectTagEnum.EnemyStealth, 20),
            (ObjectTagEnum.EnemyExplosion, 20),
            (ObjectTagEnum.EnemySimple, 20),
            (ObjectTagEnum.ObstacleShuriken, 15),
            (ObjectTagEnum.ObstacleHole, 2));

        StartCoroutine(SpawnPhysicsDebafCourutine(2, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(6, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(10, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(14, 2));

        LevelBuild(15, 30, 1, 40, CreateLevelSpawnerList());
    }

    public void Level19Config()
    {
        CreateLevelSpawnerList(
           (ObjectTagEnum.EnemyStealth, 50),
           (ObjectTagEnum.EnemyExplosion, 50),
           (ObjectTagEnum.ObstacleShuriken, 15),
           (ObjectTagEnum.ObstacleHole, 2));

        StartCoroutine(SpawnPhysicsDebafCourutine(2, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(6, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(10, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(14, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(30, 5));

        LevelBuild(40, 40, 1, 85, CreateLevelSpawnerList());
    }

    public void Level20Config()
    {
 
        CreateLevelSpawnerList((ObjectTagEnum.ItemSpeedPlus, 5),
          (ObjectTagEnum.ItemSpeedMinus, 5),
          (ObjectTagEnum.ItemTimeMinus, 5),
          (ObjectTagEnum.ItemTimePlus, 5),
          (ObjectTagEnum.EnemyStealth, 25),
          (ObjectTagEnum.EnemyExplosion, 20),
          (ObjectTagEnum.EnemySimple, 15),
          (ObjectTagEnum.ObstacleShuriken, 16),
          (ObjectTagEnum.ObstacleHole, 2));

        StartCoroutine(SpawnPhysicsDebafCourutine(2, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(6, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(10, 2));
        StartCoroutine(SpawnPhysicsDebafCourutine(14, 2));

        LevelBuild(15, 30, 1, 40, CreateLevelSpawnerList());
    }


    private List<ObjectTag> CreateLevelSpawnerList(params (ObjectTagEnum tag, int count)[] configs)
    {

        foreach (var (tag, count) in configs)
        {
            for (int i = 0; i < count; i++)
            {
                spawnerObjectTag.objectTags.Add(objectTagsAll[Convert.ToInt32(tag)]);
            }
        }

        return spawnerObjectTag.objectTags;
    }

    private IEnumerator SpawnPhysicsDebafCourutine(int timeSpawn, int duration)
    {
        yield return new WaitForSeconds(timeSpawn);

        physicsDebaf.PhysicsDebafOn();

        yield return new WaitForSeconds(duration);

        physicsDebaf.PhysicsDebafOff();
    }
}
