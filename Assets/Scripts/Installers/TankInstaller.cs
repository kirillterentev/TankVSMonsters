using BattleVehicle;
using UnityEngine;
using Zenject;

public class TankInstaller : MonoInstaller
{
	[SerializeField]
	private GameObject healthBar;

	public override void InstallBindings()
	{
		Container.Bind<IIndicator>().To<TankIndicator>()
			.FromNewComponentOn(healthBar).AsTransient();
	}
}
