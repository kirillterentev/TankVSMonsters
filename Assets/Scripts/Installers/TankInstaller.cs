using BattleVehicle;
using UnityEngine;
using Zenject;

public class TankInstaller : MonoInstaller
{
	[SerializeField]
	private GameObject inputManager;
	[SerializeField]
	private GameObject healthBar;
	[SerializeField]
	private GameObject weaponManager;
	[SerializeField]
	private GameObject mover;

	public override void InstallBindings()
	{
		Container.Bind<IInputManager>().To<TankInputManager>()
			.FromComponentOn(inputManager).AsSingle();
		Container.Bind<IIndicator>().To<TankIndicator>()
			.FromComponentOn(healthBar).AsSingle();
		Container.Bind<IWeaponManager>().To<TankWeaponManager>()
			.FromComponentOn(weaponManager).AsSingle();
		Container.Bind<IMover>().To<TankMover>()
			.FromComponentOn(mover).AsSingle();
		Container.Bind<AbstractShellPool>().To<ShellPool>().AsTransient().NonLazy();
		Container.BindFactory<string, AbstractShell, AbstractShellFactory>().FromFactory<ShellFactory>();
	}
}
