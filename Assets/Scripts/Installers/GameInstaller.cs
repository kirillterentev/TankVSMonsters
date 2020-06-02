using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	[SerializeField]
	private TankInputManager inputManager;

    public override void InstallBindings()
    {
	    Container.Bind<IInputManager>().To<TankInputManager>().FromInstance(inputManager).AsSingle().NonLazy();
    }
}