using Zenject;
using UnityEngine;

public sealed class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement playerMovement;

    public override void InstallBindings()
    {           
        this.Container.Bind<EndRoundWindow>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<Timer>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<EndRoundScript>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<SpawnerObjectTag>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<LevelConfigSpawner>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<ButtonScripts>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<StartGameMenu>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<HideLevelsView>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<ExpScript>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<LevelsStars>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<GiveCoins>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<CoinsView>().FromComponentInHierarchy().AsSingle();       
        this.Container.Bind<ChangeSkin>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<PurchaseSystem>().FromComponentInHierarchy().AsSingle();       
        this.Container.Bind<SpawnerShuriken>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<PauseGame>().FromComponentInHierarchy().AsSingle();
        this.Container.Bind<PhysicsDebaf>().FromComponentInHierarchy().AsSingle();

        this.Container.Bind<StoredData>().AsSingle();
        this.Container.Bind<StartRoundScript>().AsSingle();
        this.Container.Bind<SaveJson>().AsSingle();
        this.Container.Bind<AddItem>().AsSingle();
        
        this.Container.BindInterfacesTo<CharacterInputController>().AsSingle().WithArguments(this.playerMovement).NonLazy();
    }
}
