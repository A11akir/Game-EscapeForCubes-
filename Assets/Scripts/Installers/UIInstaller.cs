using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField]
    private CoinsView coinsView;
    public override void InstallBindings()
    {
        this.Container.BindInterfacesTo<MoneyPresenter>().AsCached().WithArguments(this.coinsView).NonLazy();
    }
}
