using System;
using UnityEngine;
using Zenject;

public class EndRoundScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Rigidbody2D rbPlayer;

    private Timer timer;
    private ExpScript expScript;
    private SpawnerObjectTag spawnerObjectTag;
    private LevelsStars levelsStars;
    private PhysicsDebaf physicsDebaf;

    public event Action RoundChanged;

    [Inject]
    private void Construct(Timer timer, ExpScript expScript, SpawnerObjectTag spawnerObjectTag, HideLevelsView hideLevelsView, LevelsStars levelsStars, PhysicsDebaf physicsDebaf)
    {
        this.timer = timer;
        this.expScript = expScript;
        this.spawnerObjectTag = spawnerObjectTag;
        this.levelsStars = levelsStars;
        this.physicsDebaf = physicsDebaf;
    }

    private void OnEnable()
    {
        rbPlayer = playerTransform.gameObject.GetComponent<Rigidbody2D>();

        expScript.ExpChanged += OnExpChanged;
        timer.TimeChanged += OnTimeChanged;
        RoundChanged += RefreshSpawner;
    }

    private void OnDisable()
    {
        expScript.ExpChanged -= OnExpChanged;
        timer.TimeChanged -= OnTimeChanged;
        RoundChanged -= RefreshSpawner;
    }
      
    private void OnExpChanged(float expPercentage)
    {
        if (expScript.CurrentExp >= expScript.MaxExp)
        {
            RoundChanged();

            Time.timeScale = 0f;
        }
    }

    private void OnTimeChanged(float SecondCountMax, float secondCount)
    {

        if (timer.SecondCountMax <= 0)
        {
            RoundChanged();

            Time.timeScale = 0f;         
        }
    }

    public void RefreshRound()
    {
        rbPlayer.velocity = Vector2.zero;
        expScript.CurrentExp = 0;
        expScript.ChangedExp(0);
        spawnerObjectTag.StopAllCoroutines();
        playerTransform.position = new Vector3(0, 0, 0);
        StopAllCoroutines();
        physicsDebaf.PhysicsDebafOff();

        levelsStars.scoreOneStar = 0;
        levelsStars.scoreTwoStar = 0;
        levelsStars.scoreThreeStar = 0;
    }

    public void RefreshSpawner()
    {
        spawnerObjectTag.pool.ClearPool();
        spawnerObjectTag.objectTags.Clear();
        spawnerObjectTag.PoolCount = 0;
    }
}
